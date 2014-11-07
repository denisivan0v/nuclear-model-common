using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class BulkDeleteIdentity : OperationIdentityBase<BulkDeleteIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get { return OperationIdentityIds.BulkDeleteIdentity; }
        }

        public override string Description
        {
            get { return "Bulk delete"; }
        }
    }
}
