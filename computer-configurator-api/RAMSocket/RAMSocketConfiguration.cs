using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.RAMSocket
{
    public class RAMSocketConfiguration : IEntityTypeConfiguration<RAMSocket>
    {
        public void Configure(EntityTypeBuilder<RAMSocket> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("ramsocket_pkey");

            builder.HasIndex(e => e.Version, "ramsocket_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
