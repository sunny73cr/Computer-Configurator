using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.FanDiameter
{
    public class FanDiameterConfiguration : IEntityTypeConfiguration<FanDiameter>
    {
        public void Configure(EntityTypeBuilder<FanDiameter> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("fandiameter_pkey");

            builder.HasIndex(e => e.Diameter, "fandiameter_diameter_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Diameter)
                .HasColumnName("diameter")
                .HasColumnType("integer");
        }
    }
}
