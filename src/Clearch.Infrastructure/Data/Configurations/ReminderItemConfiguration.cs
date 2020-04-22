using System;
using Clearch.Domain.Entities.ReminderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clearch.Infrastructure.Data.Configurations
{
    public class ReminderItemConfiguration : IEntityTypeConfiguration<ReminderItem>
    {
        public void Configure(EntityTypeBuilder<ReminderItem> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(200).IsRequired();
        }
    }
}
