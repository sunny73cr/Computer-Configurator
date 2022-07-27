using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisFilterSupport
{
    public class ChassisFilterSupportConfiguration : IEntityTypeConfiguration<ChassisFilterSupport>
    {
        public void Configure(EntityTypeBuilder<ChassisFilterSupport> builder)
        {
            builder.ToTable("chassis_filtersupport");

            builder.HasKey(e => new { e.ChassisUUID, e.ChassisZoneUUID})
                .HasName("chassis_filtersupport_pkey");

            builder.Property(e => e.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(e => e.ChassisZoneUUID)
                .HasColumnName("chassiszoneuuid")
                .HasColumnType("uuid");

            builder.Property(e => e.Removeable)
                .HasColumnName("removeable")
                .HasColumnType("boolean");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.FilterSupport)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_filtersupport_chassisuuid_fkey");

            builder.HasOne(d => d.ChassisZone)
                .WithMany()
                .HasForeignKey(d => d.ChassisZoneUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_filtersupport_chassiszoneuuid_fkey");
        }
    }
}
