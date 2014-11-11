using System;

using NuClear.Model.Common.Entities;

namespace NuClear.Model.Common.Operations.Identity
{
    public sealed class StrictOperationIdentity : IEquatable<StrictOperationIdentity>
    {
        private readonly IOperationIdentity _operationIdentity;
        private readonly EntitySet _entitySet;

        public StrictOperationIdentity(IOperationIdentity operationIdentity, EntitySet entitySet)
        {
            if (operationIdentity == null)
            {
                throw new ArgumentNullException("operationIdentity");
            }

            if (entitySet == null)
            {
                throw new ArgumentNullException("entitySet");
            }

            _operationIdentity = operationIdentity;
            _entitySet = entitySet;
        }

        public IOperationIdentity OperationIdentity
        {
            get { return _operationIdentity; }
        }

        public EntityType[] Entities
        {
            get { return _entitySet.Entities; }
        }

        #region Implementation of IEquatable<EntitiesDescriptor>

        bool IEquatable<StrictOperationIdentity>.Equals(StrictOperationIdentity other)
        {
            return Equals(other);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (typeof(StrictOperationIdentity) != obj.GetType())
            {
                return false;
            }

            var other = (StrictOperationIdentity)obj;
            return OperationIdentity.Equals(other.OperationIdentity) && _entitySet.Equals(other._entitySet);
        }

        public override int GetHashCode()
        {
            return _operationIdentity.GetHashCode() ^ _entitySet.GetHashCode(); //_entitySet.Entities.EvaluateHash();
        }

        public override string ToString()
        {
            return _operationIdentity + ". " + _entitySet;
        }
    }
}
