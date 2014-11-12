using System;
using System.Linq;

namespace NuClear.Model.Common.Entities
{
    public abstract class EntityType
    {
        private static readonly EntityTypeInstancesStorage InstancesStorage = new EntityTypeInstancesStorage();
        private readonly IIdentity _identity;
        
        protected EntityType(int id, string description) : this(new EntityIdentity(id, description))
        {
        }

        private EntityType(IIdentity identity)
        {
            _identity = identity;
        }

        public static EntityType None
        {
            get { return GetEntityType<EntityTypeNone>() ?? new EntityTypeNone(); }
        }

        public static EntityType All
        {
            get
            {
                return GetEntityType<EntityTypeAll>() ?? new EntityTypeAll();
            }
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public static explicit operator int(EntityType entityType)
        {
            return entityType._identity.Id;
        }
        
        public static T GetEntityType<T>() where T : EntityType
        {
            T instance;
            return InstancesStorage.TryGetInstance(typeof(T), out instance) ? instance : null;
        }

        public static bool TryParse<T>(string description, out T value) where T : EntityType
        {
            var entityTypes = InstancesStorage.GetAllInstances();
            value = (T)entityTypes.FirstOrDefault(x => x.Identity.Description.Equals(description, StringComparison.OrdinalIgnoreCase));

            return value != null;
        }
        
        public override string ToString()
        {
            return string.Format("Type name: {0}, Id = {1}, Value = {2}", GetType().Name, _identity.Id, _identity.Description);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = (EntityType)obj;
            return _identity.Equals(other._identity);
        }

        public override int GetHashCode()
        {
            return _identity.Id.GetHashCode();
        }

        protected static void Initialize(EntityType entityType)
        {
            if (!InstancesStorage.Contains(entityType))
            {
                InstancesStorage.Add(entityType);
            }
        }

        private class EntityIdentity : IIdentity
        {
            private readonly int _id;
            private readonly string _description;

            public EntityIdentity(int id, string description)
            {
                _id = id;
                _description = description;
            }

            public int Id
            {
                get { return _id; }
            }

            public string Description
            {
                get { return _description; }
            }

            public bool Equals(IIdentity other)
            {
                if (other == null)
                {
                    return false;
                }

                return _id == other.Id;
            }
        }
    }
}