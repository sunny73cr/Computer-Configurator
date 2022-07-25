using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisRadiatorSupport
{
    public class ChassisRadiatorSupportConfiguration : IEntityTypeConfiguration<ChassisRadiatorSupport>
    {
        public void Configure(EntityTypeBuilder<ChassisRadiatorSupport> builder)
        {
            builder.ToTable("chassis_radiatorsupport");

            builder.HasKey(e => new { e.ChassisUUID, e.RadiatorSizeUUID, e.ChassisZoneUUID})
                .HasName("chassis_radiatorsupport_pkey");

            builder.Property(x => x.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");
            
            builder.Property(x => x.RadiatorSizeUUID)
                .HasColumnName("radiatorsizeuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.ChassisZoneUUID)
                .HasColumnName("chassiszoneuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.MaximumWidthMM)
                .HasColumnName("maximumwidthmm")
                .HasColumnType("integer");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.ChassisRadiatorSupport)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_radiatorsupport_chassisuuid_fkey");

            builder.HasOne(d => d.RadiatorSize)
                .WithMany()
                .HasForeignKey(d => d.RadiatorSizeUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_radiatorsupport_radiatorsizeuuid_fkey");

            builder.HasOne(d => d.ChassisZone)
                .WithMany()
                .HasForeignKey(d => d.ChassisZoneUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_radiatorsupport_chassiszoneuuid_fkey");
        }
    }
}
