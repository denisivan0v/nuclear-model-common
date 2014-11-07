namespace NuClear.Model.Common.Operations.Identity
{
    public static class OperationIdentityUtils
    {
        public static bool IsEntitySpecific(this IOperationIdentity identity)
        {
            return identity is IEntitySpecificOperationIdentity;
        }

        public static bool IsNonCoupled(this IOperationIdentity identity)
        {
            return identity is INonCoupledOperationIdentity;
        }
    }
}
