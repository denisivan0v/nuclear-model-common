using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{  
    [DataContract]
    public class CompleteIdentity : OperationIdentityBase<CompleteIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.CompleteIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Complete";
            }
        }
    }    
}
