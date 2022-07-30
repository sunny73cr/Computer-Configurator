using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.SATAHDD
{
    public class SATAHDDConfiguration : IEntityTypeConfiguration<SATAHDD>
    {
        public void Configure(EntityTypeBuilder<SATAHDD> builder)
        {
            builder.ToTable("satahdd");

            builder.Property(x => x.SpindleRPM)
                .HasColumnName("spindlerpm")
                .HasColumnType("integer");

            builder.Property(x => x.MountedStorageFormFactorUUID)
                .HasColumnName("mountedstorageformfactoruuid")
                .HasColumnType("uuid");

            builder.HasOne(d => d.Storage)
                .WithOne()
                .HasForeignKey<SATAHDD>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("satahdd_storageuuid_fkey");

            builder.HasOne(d => d.MountedStorageFormFactor)
                .WithMany()
                .HasForeignKey(d => d.MountedStorageFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("satahdd_mountedstorageformfactoruuid_fkey");
        }
    }
}
