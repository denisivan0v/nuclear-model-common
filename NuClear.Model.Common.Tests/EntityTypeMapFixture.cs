using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NuClear.Model.Common.Entities;

using Xunit;

namespace NuClear.Model.Common.Tests
{
    public class EntityTypeMapFixture
    {
        public EntityTypeMapFixture()
        {
            EntityTypeMappingRegistry.Initialize(Enumerable.Empty<IEntityType>(), Enumerable.Empty<Type>());
            EntityTypeMappingRegistry.AddMappings(new Dictionary<IEntityType, Type>
                                                      {
                                                          { EntityType.Instance.SampleEntity(), typeof(SampleEntity) }
                                                      });
        }

        [Fact]
        public void TryGetEntityName_should_return_proper_entity_type()
        {
            IEntityType entityType;
            typeof(SampleEntity).TryGetEntityName(out entityType).Should().Be(true);
            entityType.Should().BeSameAs(EntityType.Instance.SampleEntity());
        }

        [Fact]
        public void TryGetEntityType_should_return_proper_clr_entity_type()
        {
            Type clrType;
            EntityType.Instance.SampleEntity().TryGetEntityType(out clrType).Should().Be(true);
            clrType.Should().BeSameAs(typeof(SampleEntity));
        }

        [Fact]
        public void AsEntityName_should_return_proper_entity_type()
        {
            typeof(SampleEntity).AsEntityName().Should().BeSameAs(EntityType.Instance.SampleEntity());
        }

        [Fact]
        public void AsEntityType_should_return_proper_clr_entity_type()
        {
            EntityType.Instance.SampleEntity().AsEntityType().Should().Be(typeof(SampleEntity));
        }

        [Fact]
        public void AsEntityTypes_should_return_array_of_proper_entity_types()
        {
            new[] { typeof(SampleEntity) }.AsEntityTypes().Should().Equal(new IEntityType[] { EntityType.Instance.SampleEntity() });
        }

        [Fact]
        public void AsEntitySet_should_return_proper_entity_set()
        {
            new[] { typeof(SampleEntity) }.AsEntitySet().Should().Be(new EntitySet(EntityType.Instance.SampleEntity()));
        }
    }
}