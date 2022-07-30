using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.SATASSD
{
    public class SATASSDConfiguration : IEntityTypeConfiguration<SATASSD>
    {
        public void Configure(EntityTypeBuilder<SATASSD> builder)
        {
            builder.ToTable("satassd");

            builder.Property(x => x.MountedStorageFormFactorUUID)
                .HasColumnName("mountedstorageformfactoruuid")
                .HasColumnType("uuid");

            builder.HasOne(d => d.Storage)
                .WithOne()
                .HasForeignKey<SATASSD>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("satassd_storageuuid_fkey");

            builder.HasOne(d => d.MountedStorageFormFactor)
                .WithMany()
                .HasForeignKey(d => d.MountedStorageFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("satassd_mountedstorageformfactoruuid_fkey");
        }
    }
}
