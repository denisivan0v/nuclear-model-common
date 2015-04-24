using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NuClear.Model.Common.Operations.Identity
{
    public sealed class OperationIdentityRegistry : IOperationIdentityRegistry
    {
        private readonly Type _operationIdentityIndicator = typeof(IOperationIdentity);
        private readonly IReadOnlyDictionary<int, IOperationIdentity> _identitiesMap;

        public OperationIdentityRegistry(IEnumerable<IOperationIdentity> identities)
        {
            var mergedIdentities = GetGenericOperationIdentities(_operationIdentityIndicator.GetTypeInfo()).Concat(identities).ToArray();

            var nonUniqueIdentities = mergedIdentities.GroupBy(x => x.Id).Where(x => x.Skip(1).Any()).ToArray();
            if (nonUniqueIdentities.Any())
            {
                var sb = new StringBuilder("Operation identity id have to be unique constraint is violated. Violations: ");
                nonUniqueIdentities.Aggregate(sb,
                                              (builder, pair) =>
                                              builder.AppendLine("Descriptor id=" + pair.Key + ". " + string.Join(";", pair.Select(t => t.GetType().Name))));
                throw new InvalidOperationException(sb.ToString());
            }

            _identitiesMap = mergedIdentities.ToDictionary(x => x.Id);
        }
        
        TOperationIdentity IOperationIdentityRegistry.GetIdentity<TOperationIdentity>()
        {
            var identityType = typeof(TOperationIdentity);
            return (TOperationIdentity)ResolveIdentity(identityType);
        }

        IOperationIdentity IOperationIdentityRegistry.GetIdentity(Type identityType)
        {
            if (!_operationIdentityIndicator.GetTypeInfo().IsAssignableFrom(identityType.GetTypeInfo()))
            {
                throw new InvalidOperationException(string.Format("Can't get operation identity, specified type {0} is invalid", identityType));
            }

            return ResolveIdentity(identityType);
        }

        IOperationIdentity IOperationIdentityRegistry.GetIdentity(int operationId)
        {
            IOperationIdentity identity;
            if (!_identitiesMap.TryGetValue(operationId, out identity))
            {
                throw new InvalidOperationException("Unsupported operation id=" + operationId);
            }

            return identity;
        }

        IOperationIdentity[] IOperationIdentityRegistry.Identities 
        {
            get
            {
                return _identitiesMap.Values.ToArray();
            }
        }

        private static IEnumerable<IOperationIdentity> GetGenericOperationIdentities(TypeInfo operationIdentityIndicator)
        {
            var genericOperationIdentityTypes = operationIdentityIndicator.Assembly.ExportedTypes
                                                                          .Select(x => x.GetTypeInfo())
                                                                          .Where(operationIdentityIndicator.IsAssignableFrom)
                                                                          .Where(x => !x.IsInterface && !x.IsAbstract)
                                                                          .ToArray();

            return genericOperationIdentityTypes.Select(x => (IOperationIdentity)Activator.CreateInstance(x.AsType()));
        }

        private IOperationIdentity ResolveIdentity(Type identityType)
        {
            return _identitiesMap.Values.Single(i => i.GetType() == identityType);
        }
    }
}
