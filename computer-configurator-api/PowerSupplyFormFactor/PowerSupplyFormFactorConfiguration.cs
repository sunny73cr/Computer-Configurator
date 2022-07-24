using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.PowerSupplyFormFactor
{
    public class PowerSupplyFormFactorConfiguration : IEntityTypeConfiguration<PowerSupplyFormFactor>
    {
        public void Configure(EntityTypeBuilder<PowerSupplyFormFactor> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("powersupplyformfactor_pkey");

            builder.HasIndex(e => e.FormFactor, "powersupplyformfactor_formfactor_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.FormFactor)
                .HasColumnName("formfactor")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);
        }
    }
}
