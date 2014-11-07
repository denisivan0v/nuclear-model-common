using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ModifySimplifiedModelEntityIdentity : 
        OperationIdentityBase<ModifySimplifiedModelEntityIdentity>,
        IEntitySpecificOperationIdentity,
        ISimplifiedModelIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ModifySimplifiedModelEntityIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "ModifySimplifiedModelEntity";
            }
        }
    }
}