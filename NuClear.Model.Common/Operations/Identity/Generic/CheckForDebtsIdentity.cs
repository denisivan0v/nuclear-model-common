using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class CheckForDebtsIdentity : OperationIdentityBase<CheckForDebtsIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.CheckForDebtsIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "CheckForDebts";
            }
        }
    }
}