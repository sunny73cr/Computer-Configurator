using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Part
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("part");

            builder.HasKey(e => e.UUID)
                .HasName("part_pkey");

            builder.HasIndex(e => new { e.ManufacturerUUID, e.Model }, "part_manufacturer_model_unique")
                .IsUnique();

            builder.Property(e => e.ManufacturerUUID)
                .HasColumnName("manufactureruuid")
                .HasColumnType("uuid");

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.LongDescription)
                .HasColumnName("longdescription")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(e => e.Model)
                .HasColumnName("model")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(7,2)")
                .HasPrecision(7, 2);

            builder.Property(e => e.ShortDescription)
                .HasColumnName("shortdescription")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(d => d.Manufacturer)
                .WithMany()
                .HasForeignKey(d => d.ManufacturerUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("part_manufactureruuid_fkey");
        }
    }
}
