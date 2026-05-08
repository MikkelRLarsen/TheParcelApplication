using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;

namespace TerminalService.Infrastructure.ModelConfigurations
{
	internal sealed class TerminalAllocationConfiguration : IEntityTypeConfiguration<TerminalAllocation>
	{
		public void Configure(EntityTypeBuilder<TerminalAllocation> builder)
		{
			builder.ToTable("TerminalAllocation");

			builder.HasKey(t => t.Id);

			builder
				.Property(t => t.Id)
				.ValueGeneratedNever()
				.IsRequired();

			builder
				.Property(t => t.TerminalId)
				.IsRequired();

			builder
				.Property(t => t.TrackingNumber)
				.IsRequired();

			builder
				.Property(t => t.Version)
				.IsRequired();

			builder.ComplexProperty(t => t.AllocationDate, date =>
			{
				date.Property(d => d.DateTime)
					.IsRequired();
			});

			builder.HasIndex(t => new { t.TerminalId, t.Version })
				.IsUnique();
		}
	}
}
