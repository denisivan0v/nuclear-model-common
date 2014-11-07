using System;
using System.Runtime.Serialization;

namespace NuClear.Model.Common.Entities
{
    [DataContract]
    public sealed class EntitySet : IEquatable<EntitySet>
    {
        [DataMember]
        private readonly IEntityName[] _entities;

        public EntitySet(params IEntityName[] entities)
        {
            if (entities == null || entities.Length == 0)
            {
                throw new ArgumentException("Argument has invaid value");
            }

            _entities = entities;
        }

        public IEntityName[] Entities
        {
            get
            {
                return _entities;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (typeof(EntitySet) != obj.GetType())
            {
                return false;
            }

            var other = (EntitySet)obj;

            if (ReferenceEquals(Entities, other.Entities))
            {
                return true;
            }

            if (Entities.Length != other.Entities.Length)
            {
                return false;
            }

            for (int i = 0; i < Entities.Length; i++)
            {
                if (Entities[i] != other.Entities[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Entities.EvaluateHashSimplified();
        }

        public override string ToString()
        {
            return Entities.EntitiesToString();
        }

        bool IEquatable<EntitySet>.Equals(EntitySet other)
        {
            return Equals(other);
        }
    }
}