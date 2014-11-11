namespace NuClear.Model.Common.Entities
{
    public abstract class EntityType
    {
        private static readonly EntityTypeInstancesStorage InstancesStorage = new EntityTypeInstancesStorage();
        private readonly IIdentity _identity;
        
        protected EntityType(int id, string description) 
            : this(new EntityIdentity(id, description))
        {
        }

        private EntityType(IIdentity identity)
        {
            _identity = identity;
        }

        public static EntityType None
        {
            get { return Create<EntityTypeNone>(); }
        }

        public static EntityType All
        {
            get { return Create<EntityTypeAll>(); }
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public static T Create<T>() where T : EntityType, new()
        {
            T instance;
            if (!InstancesStorage.TryGetInstance(typeof(T), out instance))
            {
                instance = new T();
                InstancesStorage.Add(instance);
            }

            return instance;
        }

        public static explicit operator int(EntityType entityType)
        {
            return entityType._identity.Id;
        }

        public override string ToString()
        {
            return string.Format("Type name: {0}, id = {1}", GetType().Name, _identity.Id);
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