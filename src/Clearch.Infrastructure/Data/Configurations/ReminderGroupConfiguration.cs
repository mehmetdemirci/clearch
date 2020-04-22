using System;
using Clearch.Domain.Entities.ReminderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clearch.Infrastructure.Data.Configurations
{
    public class ReminderGroupConfiguration : IEntityTypeConfiguration<ReminderGroup>
    {
        public void Configure(EntityTypeBuilder<ReminderGroup> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(200).IsRequired();

            builder.HasMany(x => x.Items).WithOne(x => x.ReminderGroup).HasForeignKey(x => x.ReminderGroupId);

            builder.HasIndex(x => x.Owner);
        }
    }
}
