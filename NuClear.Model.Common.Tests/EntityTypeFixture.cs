﻿using FluentAssertions;

using NuClear.Model.Common.Entities;

using Xunit;

namespace NuClear.Model.Common.Tests
{
    public class EntityTypeFixture
    {
        [Fact]
        public void EntityType_should_be_able_to_cast_to_int()
        {
            var entityType = EntityType.None;
            var casted = (int)entityType;

            casted.Should().Be(entityType.Identity.Id);
        }

        [Fact]
        public void Same_objects_of_EntityType_should_be_reference_equal_to_each_other()
        {
            EntityType.None.Should().BeSameAs(EntityType.None);
        }

        [Fact]
        public void Different_objects_of_EntityType_should_not_be_reference_equal_to_each_other()
        {
            EntityType.None.Should().NotBe(EntityType.All);
            EntityType.None.Should().NotBeSameAs(EntityType.All);
        }
    }
}