using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisZone
{
    public class ChassisZoneConfiguration : IEntityTypeConfiguration<ChassisZone>
    {
        public void Configure(EntityTypeBuilder<ChassisZone> builder)
        {
            builder.ToTable("chassiszone");

            builder.HasKey(e => e.UUID)
                .HasName("chassiszone_pkey");

            builder.HasIndex(e => e.Zone, "chassiszone_zone_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Zone)
                .HasColumnName("zone")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
