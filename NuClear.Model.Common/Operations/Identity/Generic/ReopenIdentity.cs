using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{  
    [DataContract]
    public class ReopenIdentity : OperationIdentityBase<ReopenIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ReopenIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Reopen";
            }
        }
    }    
}
