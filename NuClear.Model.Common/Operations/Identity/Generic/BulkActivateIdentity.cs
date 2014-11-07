using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class BulkActivateIdentity : OperationIdentityBase<BulkActivateIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get { return OperationIdentityIds.BulkActivateIdentity; }
        }

        public override string Description
        {
            get { return "Bulk activate"; }
        }
    }
}
