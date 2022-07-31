using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.BenchmarkedResolution
{
    public class BenchmarkedResolutionConfiguration : IEntityTypeConfiguration<BenchmarkedResolution>
    {
        public void Configure(EntityTypeBuilder<BenchmarkedResolution> builder)
        {
            builder.ToTable("benchmarkedresolution");

            builder.HasKey(e => e.UUID).HasName("benchmarkedresolution_pkey");

            builder.HasIndex(e => new { e.PixelWidth, e.PixelHeight }, "benchmarkedresolution_pixelarea_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.PixelWidth)
                .HasColumnName("pixelwidth")
                .HasColumnType("integer");

            builder.Property(e => e.PixelHeight)
                .HasColumnName("pixelheight")
                .HasColumnType("integer");
        }
    }
}
