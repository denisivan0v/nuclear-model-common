using System.Linq;

using FluentAssertions;

using NuClear.Model.Common.Operations.Identity;
using NuClear.Model.Common.Operations.Identity.Generic;

using Xunit;

namespace NuClear.Model.Common.Tests
{
    public class OperationIdentityRegistryFixture
    {
        [Fact]
        public void OperationIdentityRegistry_Should_Contain_Generic_Operation_Identities_By_Default()
        {
            var registry = new OperationIdentityRegistry(Enumerable.Empty<IOperationIdentity>()) as IOperationIdentityRegistry;

            var assignIdentity = registry.GetIdentity<AssignIdentity>();
            assignIdentity.Should().Be(AssignIdentity.Instance);
        }
    }
}