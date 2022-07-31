using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.PowerSupply
{
    public class PowerSupplyConfiguration : IEntityTypeConfiguration<PowerSupply>
    {
        public void Configure(EntityTypeBuilder<PowerSupply> builder)
        {
            builder.ToTable("powersupply");

            builder.Property(x => x.MaximumOutputWatts)
                .HasColumnName("maximumoutputwatts")
                .HasColumnType("integer");

            builder.Property(x => x.PowerSupplyFormFactorUUID)
                .HasColumnName("powersupplyformfactoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.LengthMM)
                .HasColumnName("lengthmm")
                .HasColumnType("integer");

            builder.Property(x => x.ModularCables)
                .HasColumnName("modularcables")
                .HasColumnType("boolean");

            builder.Property(x => x.MTBF)
                .HasColumnName("mtbf")
                .HasColumnType("integer");

            builder.Property(x => x.EightyPlusRatingUUID)
                .HasColumnName("eightyplusratinguuid")
                .HasColumnType("uuid");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<PowerSupply>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("powersupply_uuid_fkey");

            builder.HasOne(d => d.EightyPlusRating)
                .WithMany()
                .HasForeignKey(d => d.EightyPlusRatingUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("powersupply_eightyplusratinguuid_fkey");

            builder.HasOne(d => d.PowerSupplyFormFactor)
                .WithMany()
                .HasForeignKey(d => d.PowerSupplyFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("powersupply_powersupplyformfactoruuid_fkey");
        }
    }
}
