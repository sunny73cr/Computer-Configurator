using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisFanSupport
{
    public class ChassisFanSupportConfiguration : IEntityTypeConfiguration<ChassisFanSupport>
    {
        public void Configure(EntityTypeBuilder<ChassisFanSupport> builder)
        {
            builder.ToTable("chassis_fansupport");

            builder.HasKey(e => new { e.ChassisUUID, e.FanDiameterUUID, e.ChassisZoneUUID})
                .HasName("chassis_fansupport_pkey");

            builder.Property(e => e.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(e => e.FanDiameterUUID)
                .HasColumnName("fandiameteruuid")
                .HasColumnType("uuid");

            builder.Property(e => e.ChassisZoneUUID)
                .HasColumnName("chassiszoneuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.MaximumWidthMM)
                .HasColumnName("maximumwidthmm")
                .HasColumnType("integer");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.FanSupport)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_fansupport_chassisuuid_fkey");

            builder.HasOne(d => d.FanDiameter)
                .WithMany()
                .HasForeignKey(d => d.FanDiameterUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_fansupport_fandiameteruuid_fkey");

            builder.HasOne(d => d.ChassisZone)
                .WithMany()
                .HasForeignKey(d => d.ChassisZoneUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_fansupport_chassiszoneuuid_fkey");
        }
    }
}
