using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.PCIEConnector
{
    public class PCIEConnectorConfiguration : IEntityTypeConfiguration<PCIEConnector>
    {
        public void Configure(EntityTypeBuilder<PCIEConnector> builder)
        {
            builder.ToTable("pcieconnector");

            builder.HasKey(e => e.UUID)
                .HasName("pcieconnector_pkey");

            builder.HasIndex(e => new { e.PCIEGenerationUUID, e.LaneCount }, "pcieconnector_lanecount_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.LaneCount)
                .HasColumnName("lanecount")
                .HasColumnType("integer");

            builder.HasOne(d => d.PCIEGeneration)
                .WithMany(p => p.PCIEConnectors)
                .HasForeignKey(d => d.PCIEGenerationUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pcieconnector_pciegenerationuuid_fkey");
        }
    }
}
