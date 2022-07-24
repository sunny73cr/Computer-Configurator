using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardFormFactor
{
    public class MotherboardFormFactorConfiguration : IEntityTypeConfiguration<MotherboardFormFactor>
    {
        public void Configure(EntityTypeBuilder<MotherboardFormFactor> builder)
        {
            builder.ToTable("motherboardformfactor");

            builder.HasKey(e => e.UUID)
                .HasName("motherboardformfactor_pkey");

            builder.HasIndex(e => e.FormFactor, "motherboardformfactor_formfactor_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.FormFactor)
                .HasColumnName("formfactor")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);
        }
    }
}
