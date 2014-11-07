using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ChangeClientIdentity : OperationIdentityBase<ChangeClientIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ChangeClientIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "ChangeClient";
            }
        }
    }
}