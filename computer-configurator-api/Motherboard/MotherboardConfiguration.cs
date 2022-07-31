using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Motherboard
{
    public class MotherboardConfiguration : IEntityTypeConfiguration<Motherboard>
    {
        public void Configure(EntityTypeBuilder<Motherboard> builder)
        {
            builder.ToTable("motherboard");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<Motherboard>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_uuid_fkey");

            builder.HasOne(d => d.CPUSocket)
                .WithMany()
                .HasForeignKey(d => d.CPUSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_cpusocketuuid_fkey");

            builder.HasOne(d => d.MotherboardChipset)
                .WithMany()
                .HasForeignKey(d => d.MotherboardChipsetUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_motherboardchipsetuuid_fkey");

            builder.HasOne(d => d.MotherboardFormFactor)
                .WithMany()
                .HasForeignKey(d => d.MotherboardFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboard_motherboardformfactoruuid_fkey");
        }
    }
}
