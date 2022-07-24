using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.DisplayConnector
{
    public class DisplayConnectorConfiguration : IEntityTypeConfiguration<DisplayConnector>
    {
        public void Configure(EntityTypeBuilder<DisplayConnector> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("displayconnector_pkey");

            builder.HasIndex(e => new { e.Interface, e.Version }, "displayconnector_interface_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Interface)
                .HasColumnName("interface")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
