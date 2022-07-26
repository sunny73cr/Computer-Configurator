using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.BenchmarkedResolution
{
    public class BenchmarkedResolutionConfiguration : IEntityTypeConfiguration<BenchmarkedResolution>
    {
        public void Configure(EntityTypeBuilder<BenchmarkedResolution> builder)
        {
            builder.ToTable("benchmarkedresolution");

            builder.HasKey(e => e.UUID)
                .HasName("benchmarkedresolution_pkey");

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

            //builder.HasData(new List<BenchmarkedResolution>()
            //{
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1280, PixelHeight = 720 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1366, PixelHeight = 768 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1440, PixelHeight = 900 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1600, PixelHeight = 900 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1920, PixelHeight = 1080 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1920, PixelHeight = 1200 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 1920, PixelHeight = 1080 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 2560, PixelHeight = 1440 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 2560, PixelHeight = 1600 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 3440, PixelHeight = 1440 },
            //    new BenchmarkedResolution() { UUID = Guid.NewGuid(), PixelWidth = 3840, PixelHeight = 2160 },
            //});
        }
    }
}
