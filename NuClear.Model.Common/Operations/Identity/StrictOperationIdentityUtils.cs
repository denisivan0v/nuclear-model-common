using System.Linq;

namespace NuClear.Model.Common.Operations.Identity
{
    public static class StrictOperationIdentityUtils
    {
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