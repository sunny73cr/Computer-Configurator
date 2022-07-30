using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUSocket
{
    public class CPUSocketConfiguration : IEntityTypeConfiguration<CPUSocket>
    {
        public void Configure(EntityTypeBuilder<CPUSocket> builder)
        {
            builder.ToTable("cpusocket");

            builder.HasKey(e => e.UUID)
                .HasName("cpusocket_pkey");

            builder.HasIndex(e => e.Version, "cpusocket_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
        }
    }
}
