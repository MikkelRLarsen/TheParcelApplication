using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutingService.Domain;
using RoutingService.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.ModelConfigurations
{
	internal sealed class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
	{
		public void Configure(EntityTypeBuilder<Terminal> builder)
		{
			builder.ToTable("Terminal");

			builder.HasKey(t => t.Id);

			builder
				.Property(t => t.Id)
				.ValueGeneratedNever()
				.IsRequired();

			builder
				.Property(t => t.Type)
				.HasConversion<string>()
				.IsRequired();


			builder.ComplexProperty(t => t.Region, region =>
			{
				region.Property(r => r.Country)
					  .HasColumnName("Country")
					  .IsRequired();

				region.Property(r => r.MainRegion)
					  .HasColumnName("MainRegion")
					  .IsRequired();

				region.Property(r => r.SubRegion)
					  .HasColumnName("SubRegion")
					  .IsRequired();
			});


			builder
				.HasMany(t => t.Edges)
				.WithOne()
				.HasForeignKey(e => e.From)
				.OnDelete(DeleteBehavior.Cascade);


			builder.Navigation(t => t.Edges)
				   .UsePropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}
