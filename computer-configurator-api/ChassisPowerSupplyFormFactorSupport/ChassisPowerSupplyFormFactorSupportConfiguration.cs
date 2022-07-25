using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport
{
    public class ChassisPowerSupplyFormFactorSupportConfiguration : IEntityTypeConfiguration<ChassisPowerSupplyFormFactorSupport>
    {
        public void Configure(EntityTypeBuilder<ChassisPowerSupplyFormFactorSupport> builder)
        {
            builder.ToTable("chassis_powersupplyformfactorsupport");

            builder.HasKey(e => new { e.ChassisUUID, e.PowerSupplyFormFactorUUID })
                .HasName("chassis_powersupplyformfactorsupport_pkey");

            builder.Property(x => x.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.PowerSupplyFormFactorUUID)
                .HasColumnName("powersupplyformfactoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.BracketRequired)
                .HasColumnName("bracketrequired")
                .HasColumnType("boolean");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.ChassisPowerSupplyFormFactorSupport)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_powersupplyformfactorsupport_chassisuuid_fkey");

            builder.HasOne(d => d.PowerSupplyFormFactor)
                .WithMany()
                .HasForeignKey(d => d.PowerSupplyFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_powersupplyformfactorsupport_psuformfactoruuid_fkey");
        }
    }
}
