namespace NuClear.Model.Common.Operations.Identity.Generic
{
    public sealed class PrintIdentity : OperationIdentityBase<PrintIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.PrintIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Печать";
            }
        }
    }
}