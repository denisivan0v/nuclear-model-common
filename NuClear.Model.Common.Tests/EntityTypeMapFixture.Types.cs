using System.Diagnostics.CodeAnalysis;

using NuClear.Model.Common.Entities;

namespace NuClear.Model.Common.Tests
{
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal static class EntityTypeExtensions
    {
        public static EntityTypeSampleEntity SampleEntity(this EntityType entityType)
        {
            return EntityTypeSampleEntity.Instance;
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal class EntityTypeSampleEntity : EntityTypeBase<EntityTypeSampleEntity>
    {
        public override int Id
        {
            get { return 1; }
        }

        public override string Description
        {
            get { return "SampleEntity"; }
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal class SampleEntity
    {
    }
}