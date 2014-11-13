namespace NuClear.Model.Common.Entities
{
    public sealed class EntityTypeAll : EntityTypeBase<EntityTypeAll>
    {
        public override int Id
        {
            get { return 1; }
        }

        public override string Description
        {
            get { return "All"; }
        }
    }
}