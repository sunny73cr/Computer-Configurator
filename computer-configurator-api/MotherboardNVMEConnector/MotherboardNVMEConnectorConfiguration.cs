using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardNVMEConnector
{
    public class MotherboardNVMEConnectorConfiguration : IEntityTypeConfiguration<MotherboardNVMEConnector>
    {
        public void Configure(EntityTypeBuilder<MotherboardNVMEConnector> builder)
        {
            builder.ToTable("motherboard_nvmeconnector");

            builder.HasKey(e => new { e.MotherboardUUID, e.PCIEGenerationUUID, e.NVMEInterfaceUUID, e.NVMEFormFactorUUID })
                .HasName("motherboard_nvmeconnector_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.NVMEFormFactorUUID)
                .HasColumnName("nvmeformfactoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.NVMEInterfaceUUID)
                .HasColumnName("nvmeinterfaceuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.PCIEGenerationUUID)
                .HasColumnName("pciegenerationuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(d => d.Motherboard)
                .WithMany(p => p.NVMEConnectors)
                .HasForeignKey(d => d.MotherboardUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_nvmeconnector_motherboarduuid_fkey");

            builder.HasOne(d => d.NVMEFormFactor)
                .WithMany()
                .HasForeignKey(d => d.NVMEFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_nvmeconnector_nvmeformfactoruuid_fkey");

            builder.HasOne(d => d.NVMEInterface)
                .WithMany()
                .HasForeignKey(d => d.NVMEInterfaceUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_nvmeconnector_nvmeinterfaceuuid_fkey");

            builder.HasOne(d => d.PCIEGeneration)
                .WithMany()
                .HasForeignKey(d => d.PCIEGenerationUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_nvmeconnector_pciegenerationuuid_fkey");
        }
    }
}
