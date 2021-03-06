﻿using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    public sealed class GetDomainEntityDtoIdentity : OperationIdentityBase<GetDomainEntityDtoIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.GetDomainEntityDtoIdentity;
            }
        }
        public override string Description
        {
            get
            {
                return "GetDomainEntity";
            }
        }
    }
}