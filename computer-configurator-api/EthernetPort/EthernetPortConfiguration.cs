using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.EthernetPort
{
    public class EthernetPortConfiguration : IEntityTypeConfiguration<EthernetPort>
    {
        public void Configure(EntityTypeBuilder<EthernetPort> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("ethernetport_pkey");

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
        }
    }
}
