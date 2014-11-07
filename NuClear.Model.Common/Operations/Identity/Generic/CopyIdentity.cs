using System;
using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity.Generic
{
    [DataContract]
    [Obsolete("CopyOrderIdentity or CopyPriceIdentity must be used")]
    public sealed class CopyIdentity : OperationIdentityBase<CopyIdentity>, IEntitySpecificOperationIdentity
    {
        public override int Id
        {
            get
            {
                return OperationIdentityIds.CopyIdentity;
            }
        }

        public override string Description
        {
            get
            {
                return "Copy";
            }
        }
    }
}