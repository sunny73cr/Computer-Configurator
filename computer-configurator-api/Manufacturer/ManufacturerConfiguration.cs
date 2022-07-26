using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Manufacturer
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("manufacturer");

            builder.HasKey(e => e.UUID)
                .HasName("manufacturer_pkey");

            builder.HasIndex(e => e.Name, "manufacturer_name_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            //builder.HasData(new List<Manufacturer>()
            //{
            //    new Manufacturer() { UUID = Guid.NewGuid(), Name = "AMD" },
            //    new Manufacturer() { UUID = Guid.NewGuid(), Name = "Intel" },
            //});
        }
    }
}
