using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardUSBPort
{
    public class MotherboardUSBPortConfiguration : IEntityTypeConfiguration<MotherboardUSBPort>
    {
        public void Configure(EntityTypeBuilder<MotherboardUSBPort> builder)
        {
            builder.ToTable("motherboard_usbport");

            builder.HasKey(x => new { x.MotherboardUUID, x.USBPortUUID })
                .HasName("motherboard_usbport_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.USBPortUUID)
                .HasColumnName("usbportuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.ExternalCount)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.USBPorts)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_usbport_motherboarduuid_fkey");

            builder.HasOne(x => x.USBPort)
                .WithMany()
                .HasForeignKey(x => x.USBPortUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_usbport_usbportuuid_fkey");
        }
    }
}
