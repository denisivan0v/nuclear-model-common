using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public class CancelIdentity : OperationIdentityBase<CancelIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.CancelIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Cancel";
            }
        }
    }    
}
