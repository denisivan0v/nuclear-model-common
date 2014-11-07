using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ListIdentity : OperationIdentityBase<ListIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ListIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "List";
            }
        }
    }
}