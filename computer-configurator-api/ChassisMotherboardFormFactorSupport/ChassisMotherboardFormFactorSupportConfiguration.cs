using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport
{
    public class ChassisMotherboardFormFactorSupportConfiguration : IEntityTypeConfiguration<ChassisMotherboardFormFactorSupport>
    {
        public void Configure(EntityTypeBuilder<ChassisMotherboardFormFactorSupport> builder)
        {
            builder.ToTable("chassis_motherboardformfactorsupport");

            builder.HasKey(x => new { x.ChassisUUID, x.MotherboardFormFactorUUID })
                .HasName("chassis_motherboardformfactorsupport_pkey");

            builder.Property(x => x.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.MotherboardFormFactorUUID)
                .HasColumnName("motherboardformfactoruuid")
                .HasColumnType("uuid");

            builder.HasOne(x => x.Chassis)
                .WithMany(x => x.MotherboardFormFactorSupport)
                .HasForeignKey(x => x.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_motherboardformfactorsupport_chassisuuid_fkey");

            builder.HasOne(x => x.MotherboardFormFactor)
                .WithMany()
                .HasForeignKey(x => x.MotherboardFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_motherboardformfactorsupport_motherboardformfactoruuis_fkey");
        }
    }
}
