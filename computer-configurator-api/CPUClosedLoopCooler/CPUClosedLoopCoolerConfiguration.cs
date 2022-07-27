using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUClosedLoopCooler
{
    public class CPUClosedLoopCoolerConfiguration : IEntityTypeConfiguration<CPUClosedLoopCooler>
    {
        public void Configure(EntityTypeBuilder<CPUClosedLoopCooler> builder)
        {
            builder.ToTable("cpucooler");

            builder.Property(x => x.RadiatorSizeUUID)
                .HasColumnName("radiatorsizeuuid")
                .HasColumnType("uuid");

            builder.HasOne(d => d.CPUCooler)
                .WithOne()
                .HasForeignKey<CPUClosedLoopCooler>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cpuclosedloopcooler_uuid_fkey");

            builder.HasOne(d => d.RadiatorSize)
                .WithMany()
                .HasForeignKey(d => d.RadiatorSizeUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cpuclosedloopcooler_radiatorsizeuuid_fkey");
        }
    }
}
