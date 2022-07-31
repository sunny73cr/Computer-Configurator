using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.NVMESSD
{
    public class NVMESSDConfiguration : IEntityTypeConfiguration<NVMESSD>
    {
        public void Configure(EntityTypeBuilder<NVMESSD> builder)
        {
            builder.ToTable("nvmessd");

            builder.HasOne(d => d.Storage)
                .WithOne()
                .HasForeignKey<NVMESSD>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nvmessd_storageuuid_fkey");

            builder.HasOne(d => d.NVMEFormFactor)
                .WithMany()
                .HasForeignKey(d => d.NVMEFormFactorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nvmessd_nvmeformfactoruuid_fkey");

            builder.HasOne(d => d.NVMEInterface)
                .WithMany()
                .HasForeignKey(d => d.NVMEInterfaceUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nvmessd_nvmeinterfaceuuid_fkey");
        }
    }
}
