using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardPCIEConnector
{
    public class MotherboardPCIEConnectorConfiguration : IEntityTypeConfiguration<MotherboardPCIEConnector>
    {
        public void Configure(EntityTypeBuilder<MotherboardPCIEConnector> builder)
        {
            builder.ToTable("motherboard_pcieconnector");

            builder.HasKey(x => new { x.MotherboardUUID, x.PCIEConnectorUUID })
                .HasName("motherboard_pcieconnector_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.PCIEConnectorUUID)
                .HasColumnName("pcieconnectoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.PCIEConnectors)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_pcieconnector_motherboarduuid_fkey");

            builder.HasOne(x => x.PCIEConnector)
                .WithMany()
                .HasForeignKey(x => x.PCIEConnectorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_pcieconnector_pcieconnectoruuid_fkey");
        }
    }
}
