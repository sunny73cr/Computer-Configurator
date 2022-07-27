using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUCoolerFan
{
    public class CPUCoolerFanConfiguration : IEntityTypeConfiguration<CPUCoolerFan>
    {
        public void Configure(EntityTypeBuilder<CPUCoolerFan> builder)
        {
            builder.ToTable("cpucooler_fan");

            builder.HasKey(x => new { x.CPUCoolerUUID, x.FanUUID })
                .HasName("cpucooler_fan_pkey");

            builder.Property(x => x.CPUCoolerUUID)
                .HasColumnName("cpucooleruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.FanUUID)
                .HasColumnName("fanuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(x => x.CPUCooler)
                .WithMany(y => y.CPUCoolerFans)
                .HasForeignKey(x => x.CPUCoolerUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cpucooler_fan_cpucooleruuid_fkey");

            builder.HasOne(x => x.Fan)
                .WithMany()
                .HasForeignKey(x => x.FanUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cpucooler_fan_fanuuid_fkey");
        }
    }
}
