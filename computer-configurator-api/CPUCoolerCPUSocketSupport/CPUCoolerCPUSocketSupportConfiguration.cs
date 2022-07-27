using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport
{
    public class CPUCoolerCPUSocketSupportConfiguration : IEntityTypeConfiguration<CPUCoolerCPUSocketSupport>
    {
        public void Configure(EntityTypeBuilder<CPUCoolerCPUSocketSupport> builder)
        {
            builder.ToTable("cpucooler_cpusocket_support");

            builder.HasKey(x => new { x.CPUCoolerUUID, x.CPUSocket })
                .HasName("cpucooler_cpusocket_support_pkey");

            builder.Property(x => x.CPUCoolerUUID)
                .HasColumnName("cpucooleruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.CPUSocketUUID)
                .HasColumnName("cpusocketuuid")
                .HasColumnType("uuid");

            builder.HasOne(x => x.CPUCooler)
                .WithMany(x => x.CPUSockets)
                .HasForeignKey(x => x.CPUCoolerUUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cpucooler_cpusocket_cpucooleruuid_fkey");

            builder.HasOne(x => x.CPUSocket)
                .WithMany()
                .HasForeignKey(x => x.CPUSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cpucooler_cpusocket_cpusocketuuid_fkey");
        }
    }
}
