using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPU
{
    public class CPUConfiguration : IEntityTypeConfiguration<CPU>
    {
        public void Configure(EntityTypeBuilder<CPU> builder)
        {
            builder.ToTable("cpu");

            builder.Property(e => e.CoreCount)
                .HasColumnName("corecount")
                .HasColumnType("integer");

            builder.Property(e => e.ThreadCount)
                .HasColumnName("threadcount")
                .HasColumnType("integer");

            builder.Property(e => e.BaseClockSpeed)
                .HasColumnName("baseclockspeed")
                .HasColumnType("integer");

            builder.Property(e => e.BoostClockSpeed)
                .HasColumnName("boostclockspeed")
                .HasColumnType("integer");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<CPU>(d => d.UUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cpu_uuid_fkey");

            builder.HasOne(d => d.CPUSocket)
                .WithMany()
                .HasForeignKey(d => d.CPUSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cpu_cpusocketuuid_fkey");
        }
    }
}
