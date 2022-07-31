using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardFanHeader
{
    public class MotherboardFanHeaderConfiguration : IEntityTypeConfiguration<MotherboardFanHeader>
    {
        public void Configure(EntityTypeBuilder<MotherboardFanHeader> builder)
        {
            builder.ToTable("motherboard_fanheader");

            builder.HasKey(x => new { x.MotherboardUUID, x.FanHeaderUUID })
                .HasName("motherboard_fanheader_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.FanHeaderUUID)
                .HasColumnName("fanheaderuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.FanHeaders)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_fanheader_motherboarduuid_fkey");

            builder.HasOne(x => x.FanHeader)
                .WithMany()
                .HasForeignKey(x => x.FanHeaderUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_fanheader_fanheaderuuid_fkey");
        }
    }
}
