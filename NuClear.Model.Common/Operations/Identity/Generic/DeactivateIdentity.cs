using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class DeactivateIdentity : OperationIdentityBase<DeactivateIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.DeactivateIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "Deactivate";
            }
        }
    }
}