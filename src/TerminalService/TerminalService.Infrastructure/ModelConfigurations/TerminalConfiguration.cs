using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerminalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalService.Infrastructure.ModelConfigurations
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

			builder
				.Property(t => t.DailyCapacity)
				.IsRequired();

			builder.ComplexProperty(t => t.Location, location =>
			{
				location.ComplexProperty(l => l.Region, region =>
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

				location.ComplexProperty(l => l.Address, address =>
				{
					address.ComplexProperty(a => a.City, city =>
					{
						city.Property(c => c.CityName)
							.HasColumnName("CityName")
							.IsRequired();

						city.Property(c => c.ZipCode)
							.HasColumnName("ZipCode")
							.IsRequired();
					});

					address.Property(a => a.Street)
						   .HasColumnName("Street")
						   .IsRequired();

					address.Property(a => a.StreetNumber)
						   .HasColumnName("StreetNumber")
						   .IsRequired();
				});
			});
		}
	}
}
