namespace NuClear.Model.Common.Entities
{
    public class EntityTypeNone : EntityTypeBase<EntityTypeNone>
    {
        public override int Id
        {
            get { return 0; }
        }

        public override string Description
        {
            get { return "None"; }
        }
    }
}