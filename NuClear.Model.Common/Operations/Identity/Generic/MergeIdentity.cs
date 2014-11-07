using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class MergeIdentity : OperationIdentityBase<MergeIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.MergeIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Объединить";
            }
        }
    }
}