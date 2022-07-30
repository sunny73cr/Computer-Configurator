using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardRAMSpeed
{
    public class MotherboardRAMSpeedConfiguration : IEntityTypeConfiguration<MotherboardRAMSpeed>
    {
        public void Configure(EntityTypeBuilder<MotherboardRAMSpeed> builder)
        {
            builder.ToTable("motherboard_ramspeed");

            builder.HasKey(x => new { x.MotherboardUUID, x.RAMSpeedUUID })
                .HasName("motherboard_ramspeed_pkey");

            builder.Property(x => x.MotherboardUUID)
                .HasColumnName("motherboarduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.RAMSpeedUUID)
                .HasColumnName("ramspeeduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.RequiresOverclock)
                .HasColumnName("requiresoverclock")
                .HasColumnType("boolean");
            
            builder.HasOne(x => x.Motherboard)
                .WithMany(x => x.SupportedRAMSpeeds)
                .HasForeignKey(x => x.MotherboardUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("motherboard_ramspeed_motherboarduuid_fkey");

            builder.HasOne(x => x.RAMSpeed)
                .WithMany()
                .HasForeignKey(x => x.RAMSpeedUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_ramspeed_ramspeeduuid_fkey");
        }
    }
}
