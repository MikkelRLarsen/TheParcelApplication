using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutingService.Domain;
using RoutingService.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.ModelConfigurations
{
	internal sealed class EdgeConfiguration : IEntityTypeConfiguration<Edge>
	{
		public void Configure(EntityTypeBuilder<Edge> builder)
		{
			builder.ToTable("Edge");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.ValueGeneratedNever()
				.IsRequired();

			builder.Property(e => e.From)
				.IsRequired();

			builder.Property(e => e.To)
				.IsRequired();

			builder.Property(e => e.Weight)
				.IsRequired();
		}
	}
}
