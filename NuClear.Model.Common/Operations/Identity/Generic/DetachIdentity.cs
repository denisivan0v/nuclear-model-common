using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class DetachIdentity : OperationIdentityBase<DetachIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.DetachIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "Detach";
            }
        }
    }
}