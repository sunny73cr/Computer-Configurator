using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardSATAConnector
{
    public class MotherboardSATAConnectorConfiguration : IEntityTypeConfiguration<MotherboardSATAConnector>
    {
        public void Configure(EntityTypeBuilder<MotherboardSATAConnector> builder)
        {
            builder.ToTable("motherboard_sataconnector");

            builder.HasKey(x => new { x.MotherboardUUID, x.SATAGenerationUUID })
                .HasName("motherboard_sataconnector_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.SATAGenerationUUID)
                .HasColumnName("satagenerationuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.SATAConnectors)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_sataconnector_motherboarduuid_fkey");

            builder.HasOne(x => x.SATAGeneration)
                .WithMany()
                .HasForeignKey(x => x.SATAGenerationUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_sataconnector_satagenerationuuid_fkey");
        }
    }
}
