using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardRAMSocket
{
    public class MotherboardRAMSocketConfiguration : IEntityTypeConfiguration<MotherboardRAMSocket>
    {
        public void Configure(EntityTypeBuilder<MotherboardRAMSocket> builder)
        {
            builder.ToTable("motherboard_ramsocket");

            builder.HasKey(x => new { x.MotherboardUUID, x.RAMSocketUUID })
                .HasName("motherboard_ramsocket_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.RAMSocketUUID)
                .HasColumnName("ramsocketuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.RAMSockets)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_ramsocket_motherboarduuid_fkey");

            builder.HasOne(x => x.RAMSocket)
                .WithMany()
                .HasForeignKey(x => x.RAMSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_ramsocket_ramsocketuuid_fkey");
        }
    }
}
