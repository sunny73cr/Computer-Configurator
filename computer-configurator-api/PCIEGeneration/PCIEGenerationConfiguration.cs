using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.PCIEGeneration
{
    public class PCIEGenerationConfiguration : IEntityTypeConfiguration<PCIEGeneration>
    {
        public void Configure(EntityTypeBuilder<PCIEGeneration> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("pciegeneration_pkey");

            builder.HasIndex(e => e.Generation, "pciegeneration_generation_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Generation)
                .HasColumnName("generation")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
