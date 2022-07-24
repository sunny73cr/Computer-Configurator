using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.RAIDMode
{
    public class RAIDModeConfiguration : IEntityTypeConfiguration<RAIDMode>
    {
        public void Configure(EntityTypeBuilder<RAIDMode> builder)
        {
            builder.ToTable("raidmode");

            builder.HasKey(e => e.UUID)
                .HasName("raidmode_pkey");

            builder.HasIndex(e => e.Mode, "raidmode_mode_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Mode)
                .HasColumnName("mode")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
