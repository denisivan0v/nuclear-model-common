namespace NuClear.Model.Common.Tests
{
    public class IdentityStub : IdentityBase<IdentityStub>
    {
        private readonly int _id;
        private readonly string _description;

        public IdentityStub(int id, string description)
        {
            _id = id;
            _description = description;
        }

        public IdentityStub(int id) : this(id, string.Empty)
        {
        }

        public IdentityStub() : this(-1, "initialized by default ctor")
        {
        }

        public override int Id
        {
            get { return _id; }
        }

        public override string Description
        {
            get { return _description; }
        }
    }
}