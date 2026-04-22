using ParcelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ParcelService.Infrastructure.ModelConfigurations
{
    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.ToTable("Parcel");
            builder.HasKey(x => x.Id);

            builder
               .Property(x => x.Id)
               .ValueGeneratedNever();

            builder.ComplexProperty(x => x.Tracking, tracking =>
            {
                tracking.Property(t => t.Status)
                        .HasConversion<string>();
            });

            builder.ComplexProperty(x => x.Sender, sender =>
            {
                sender.ComplexProperty(s => s.PersonalInformation, personalInformation =>
                {
                    personalInformation.ComplexProperty(p => p.Address);
                });
            });

			builder.ComplexProperty(x => x.Receiver, receiver =>
			{
				receiver.ComplexProperty(r => r.PersonalInformation, personalInformation =>
				{
					personalInformation.ComplexProperty(p => p.Address);
				});
			});
        }
    }
}
