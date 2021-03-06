﻿using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class QualifyIdentity : 
        OperationIdentityBase<QualifyIdentity>,
        IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.QualifyIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "Qualify";
            }
        }
    }
}