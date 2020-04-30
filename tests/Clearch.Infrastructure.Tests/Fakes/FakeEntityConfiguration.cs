using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clearch.Infrastructure.IntegrationTests
{
    public sealed class FakeEntityConfiguration : IEntityTypeConfiguration<FakeEntity>
    {
        public void Configure(EntityTypeBuilder<FakeEntity> builder)
        {
            builder.ToTable(nameof(FakeEntity));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Property1).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.Items).WithOne(x => x.FakeEntity).HasForeignKey(x => x.FakeEntityId);
        }
    }
}