using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.RadiatorSize
{
    public class RadiatorSizeConfiguration : IEntityTypeConfiguration<RadiatorSize>
    {
        public void Configure(EntityTypeBuilder<RadiatorSize> builder)
        {
            builder.ToTable("radiatorsize");

            builder.HasKey(e => e.UUID)
                .HasName("radiatorsize_pkey");

            builder.HasIndex(e => e.Size, "radiatorsize_size_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("integer");
        }
    }
}
