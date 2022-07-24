using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.USBPort
{
    public class USBPortConfiguration : IEntityTypeConfiguration<USBPort>
    {
        public void Configure(EntityTypeBuilder<USBPort> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("usbport_pkey");

            builder.HasIndex(e => new { e.Interface, e.Version }, "usbport_interface_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID).HasDefaultValueSql("gen_random_uuid()");

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
