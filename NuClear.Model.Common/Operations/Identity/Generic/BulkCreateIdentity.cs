using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class BulkCreateIdentity : OperationIdentityBase<BulkCreateIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get { return OperationIdentityIds.BulkCreateIdentity; }
        }

        public override string Description
        {
            get { return "Bulk create"; }
        }
    }
}
