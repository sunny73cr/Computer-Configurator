using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.NVMEFormFactor
{
    public class NVMEFormFactorConfiguration : IEntityTypeConfiguration<NVMEFormFactor>
    {
        public void Configure(EntityTypeBuilder<NVMEFormFactor> builder)
        {
            builder.ToTable("nvmeformfactor");

            builder.HasKey(e => e.UUID)
                .HasName("nvmeformfactor_pkey");

            builder.HasIndex(e => e.FormFactor, "nvmeformfactor_formfactor_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.FormFactor)
                .HasColumnName("formfactor")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
