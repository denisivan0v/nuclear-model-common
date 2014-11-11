using System.Linq;

using NuClear.Model.Common.Entities;
using NuClear.Model.Common.Entities.Aspects;

namespace NuClear.Model.Common.Operations.Identity
{
    public static class StrictOperationIdentityUtils
    {
        public static StrictOperationIdentity SpecificFor<TEntity>(this IEntitySpecificOperationIdentity operationIdentity)
            where TEntity : class, IEntity
        {
            return new StrictOperationIdentity(operationIdentity, new[] { typeof(TEntity) }.AsEntitySet());
        }

        public static StrictOperationIdentity SpecificFor<TEntity1, TEntity2>(this IEntitySpecificOperationIdentity operationIdentity)
            where TEntity1 : class, IEntity
            where TEntity2 : class, IEntity
        {
            return new StrictOperationIdentity(operationIdentity, new[] { typeof(TEntity1), typeof(TEntity2) }.AsEntitySet());
        }

        public static StrictOperationIdentity SpecificFor(this IEntitySpecificOperationIdentity operationIdentity, params EntityType[] entityNames)
        {
            return new StrictOperationIdentity(operationIdentity, entityNames.ToEntitySet());
        }

        public static StrictOperationIdentity NonCoupled(this INonCoupledOperationIdentity operationIdentity)
        {
            return new StrictOperationIdentity(operationIdentity, EntitySet.Create.NonCoupled);
        }

        public static string AsUriSegment(this StrictOperationIdentity strictOperationIdentity)
        {
            var identityType = strictOperationIdentity.OperationIdentity.GetType();
            return identityType.Name +
                (strictOperationIdentity.OperationIdentity.IsNonCoupled()
                       ? string.Empty
                       : ("/" + string.Join("/", strictOperationIdentity.Entities.Select(x => x.ToString()))));
        }
    }
}