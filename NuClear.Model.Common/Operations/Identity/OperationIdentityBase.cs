using System;
using System.Runtime.Serialization;

namespace NuClear.Model.Common.Operations.Identity
{
    [DataContract]
    public abstract class OperationIdentityBase<TConcreteIdentity> : IdentityBase<TConcreteIdentity>, IOperationIdentity
        where TConcreteIdentity : IdentityBase<TConcreteIdentity>, new()
    {
        bool IEquatable<IOperationIdentity>.Equals(IOperationIdentity other)
        {
            return Equals(other);
        }
    }
}