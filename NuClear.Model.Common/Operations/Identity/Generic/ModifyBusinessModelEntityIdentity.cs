﻿using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class ModifyBusinessModelEntityIdentity : 
        OperationIdentityBase<ModifyBusinessModelEntityIdentity>, 
        IEntitySpecificOperationIdentity,
        IBusinessModelIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.ModifyBusinessModelEntityIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "ModifyBusinessModelEntity";
            }
        }
    }
}