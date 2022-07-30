using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardEthernetPort
{
    public class MotherboardEthernetPortConfiguration : IEntityTypeConfiguration<MotherboardEthernetPort>
    {
        public void Configure(EntityTypeBuilder<MotherboardEthernetPort> builder)
        {
            builder.ToTable("motherboard_ethernetport");

            builder.HasKey(x => new { x.MotherboardUUID, x.EthernetPortUUID })
                .HasName("motherboard_ethernetport_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.EthernetPortUUID)
                .HasColumnName("ethernetportuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.EthernetPorts)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_ethernetport_motherboarduuid_fkey");

            builder.HasOne(x => x.EthernetPort)
                .WithMany()
                .HasForeignKey(x => x.EthernetPortUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_ethernetport_ethernetportuuid_fkey");
        }
    }
}
