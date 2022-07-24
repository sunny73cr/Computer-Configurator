using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.SATAGeneration
{
    public class SATAGenerationConfiguration : IEntityTypeConfiguration<SATAGeneration>
    {
        public void Configure(EntityTypeBuilder<SATAGeneration> builder)
        {
            builder.ToTable("satageneration");

            builder.HasKey(e => e.UUID)
                .HasName("satageneration_pkey");

            builder.HasIndex(e => e.Generation, "satageneration_generation_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Generation)
                .HasColumnName("generation")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);
        }
    }
}
