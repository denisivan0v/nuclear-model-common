using FluentAssertions;

using NuClear.Model.Common.Entities;

using Xunit;

namespace NuClear.Model.Common.Tests
{
    public class EntityTypeFixture
    {
        [Fact]
        public void EntityType_should_be_able_to_cast_to_int()
        {
            var entityType = EntityType.Instance.None();
            var casted = (int)entityType;

            casted.Should().Be(entityType.Id);
        }

        [Fact]
        public void Same_objects_of_EntityType_should_be_reference_equal_to_each_other()
        {
            EntityType.Instance.None().Should().BeSameAs(EntityType.Instance.None());
        }

        [Fact]
        public void Different_objects_of_EntityType_should_not_be_reference_equal_to_each_other()
        {
            EntityType.Instance.None().Should().NotBe(EntityType.Instance.All());
            EntityType.Instance.None().Should().NotBeSameAs(EntityType.Instance.All());
        }

        [Fact]
        public void TryParse_extension_method_should_return_instance_based_on_identity_description()
        {
            const string None = "None";
            var initializedInstance = EntityType.Instance.None();

            IEntityType instance;
            if (EntityType.Instance.TryParse(None, out instance))
            {
                instance.Should().BeSameAs(initializedInstance);
            }
        }
    }
}