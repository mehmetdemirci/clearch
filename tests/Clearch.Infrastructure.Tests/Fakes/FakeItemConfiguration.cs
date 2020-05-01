using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clearch.Infrastructure.IntegrationTests
{
    public sealed class FakeEntityItemConfiguration : IEntityTypeConfiguration<FakeEntityItem>
    {
        public void Configure(EntityTypeBuilder<FakeEntityItem> builder)
        {
            builder.ToTable(nameof(FakeEntityItem));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.PropertyItem).IsRequired().HasMaxLength(100);
        }
    }
}