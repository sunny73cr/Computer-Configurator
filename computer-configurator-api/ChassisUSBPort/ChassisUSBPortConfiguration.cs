using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisUSBPort
{
    public class ChassisUSBPortConfiguration : IEntityTypeConfiguration<ChassisUSBPort>
    {
        public void Configure(EntityTypeBuilder<ChassisUSBPort> builder)
        {
            builder.ToTable("chassis_usbport");

            builder.HasKey(e => new { e.ChassisUUID, e.USBPortUUID, e.ChassisZoneUUID})
                .HasName("chassis_usbport_pkey");

            builder.Property(x => x.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.USBPortUUID)
                .HasColumnName("usbportuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.ChassisZoneUUID)
                .HasColumnName("chassiszoneuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.ChassisUSBPort)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_usbport_chassisuuid_fkey");

            builder.HasOne(d => d.USBPort)
                .WithMany()
                .HasForeignKey(d => d.USBPortUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_usbport_usbportuuid_fkey");

            builder.HasOne(d => d.ChassisZone)
                .WithMany()
                .HasForeignKey(d => d.ChassisZoneUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_usbport_chassiszoneuuid_fkey");
        }
    }
}
