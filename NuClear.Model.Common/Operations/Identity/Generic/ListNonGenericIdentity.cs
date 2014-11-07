using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ListNonGenericIdentity : OperationIdentityBase<ListNonGenericIdentity>, INonCoupledOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ListNonGenericIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "ListNonGenericIdentity";
            }
        }
    }
}
