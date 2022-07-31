using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardDisplayConnector
{
    public class MotherboardDisplayConnectorConfiguration : IEntityTypeConfiguration<MotherboardDisplayConnector>
    {
        public void Configure(EntityTypeBuilder<MotherboardDisplayConnector> builder)
        {
            builder.ToTable("motherboard_displayconnector");

            builder.HasKey(x => new { x.MotherboardUUID, x.DisplayConnectorUUID })
                .HasName("motherboard_displayconnector_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.DisplayConnectorUUID)
                .HasColumnName("displayconnectoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.DisplayConnectors)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_displayconnector_motherboarduuid_fkey");

            builder.HasOne(x => x.DisplayConnector)
                .WithMany()
                .HasForeignKey(x => x.DisplayConnectorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_displayconnector_displayconnectoruuid_fkey");
        }
    }
}
