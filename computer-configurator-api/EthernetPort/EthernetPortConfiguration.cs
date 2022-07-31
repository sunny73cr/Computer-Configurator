using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.EthernetPort
{
    public class EthernetPortConfiguration : IEntityTypeConfiguration<EthernetPort>
    {
        public void Configure(EntityTypeBuilder<EthernetPort> builder)
        {
            builder.ToTable("ethernetport");

            builder.HasKey(e => e.UUID)
                .HasName("ethernetport_pkey");

            builder.HasIndex(x => x.Chipset, "ethernetport_chipset_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.BandwidthMBytes)
                .HasColumnName("bandwidthmbytes")
                .HasColumnType("integer");

            builder.Property(e => e.Chipset)
                .HasColumnName("chipset")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            //builder.HasData(new List<EthernetPort>()
            //{
            //    new EthernetPort() { UUID = Guid.NewGuid(), BandwidthMBytes = 100, Chipset = "Unknown" },
            //    new EthernetPort() { UUID = Guid.NewGuid(), BandwidthMBytes = 1000, Chipset = "Unknown" },
            //    new EthernetPort() { UUID = Guid.NewGuid(), BandwidthMBytes = 2500, Chipset = "Unknown" },
            //    new EthernetPort() { UUID = Guid.NewGuid(), BandwidthMBytes = 5000, Chipset = "Unknown" },
            //    new EthernetPort() { UUID = Guid.NewGuid(), BandwidthMBytes = 10000, Chipset = "Unknown" },
            //});
        }
    }
}
