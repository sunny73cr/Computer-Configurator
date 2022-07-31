using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.DisplayConnector
{
    public class DisplayConnectorConfiguration : IEntityTypeConfiguration<DisplayConnector>
    {
        public void Configure(EntityTypeBuilder<DisplayConnector> builder)
        {
            builder.ToTable("displayconnector");

            builder.HasKey(e => e.UUID).HasName("displayconnector_pkey");

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

            //builder.HasData(new List<DisplayConnector>()
            //{
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "VGA", Version = "DE-15" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "VGA", Version = "DB-15" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "VGA", Version = "HD-15" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DVI-I", Version = "Single-Link" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DVI-I", Version = "Dual-Link" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DVI-D", Version = "Single-Link" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DVI-D", Version = "Dual-Link" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.0" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.1" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.2" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.2a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.3" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.3a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.4" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.4a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "1.4b" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "2.0" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "2.0a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "2.0b" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "HDMI", Version = "2.1" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.0" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.1" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.2" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.2a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.3" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.4" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "1.4a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "DisplayPort", Version = "2.0" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.0" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.1" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.2" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.2a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.3" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.4" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "1.4a" },
            //    new DisplayConnector() { UUID = Guid.NewGuid(), Interface = "Mini DisplayPort", Version = "2.0" }
            //});
        }
    }
}
