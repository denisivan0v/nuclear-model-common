using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ActionHistoryIdentity : OperationIdentityBase<ActionHistoryIdentity>, INonCoupledOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ActionHistoryIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "ActionHistory";
            }
        }
    }
}