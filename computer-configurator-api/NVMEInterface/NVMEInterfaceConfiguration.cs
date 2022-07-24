using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.NVMEInterface
{
    public class NVMEInterfaceConfiguration : IEntityTypeConfiguration<NVMEInterface>
    {
        public void Configure(EntityTypeBuilder<NVMEInterface> builder)
        {
            builder.ToTable("nvmeinterface");

            builder.HasKey(e => e.UUID)
                .HasName("nvmeinterface_pkey");

            builder.HasIndex(e => e.Interface, "nvminterface_interface_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Interface)
                .HasColumnName("interface")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
