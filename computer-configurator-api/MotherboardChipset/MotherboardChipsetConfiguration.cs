using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MotherboardChipset
{
    public class MotherboardChipsetConfiguration : IEntityTypeConfiguration<MotherboardChipset>
    {
        public void Configure(EntityTypeBuilder<MotherboardChipset> builder)
        {
            builder.ToTable("motherboardchipset");

            builder.HasKey(e => e.UUID)
                .HasName("motherboardchipset_pkey");

            builder.HasIndex(e => new { e.ManufacturerUUID, e.Version}, "motherboardchipset_manufacturer_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.ManufacturerUUID)
                .HasColumnName("manufactureruuid")
                .HasColumnType("uuid");

            builder.Property(e => e.CPUSocketUUID)
                .HasColumnName("cpusocketuuid")
                .HasColumnType("uuid");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.HasOne(d => d.Manufacturer)
                .WithMany()
                .HasForeignKey(d => d.ManufacturerUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboardchipset_manufactureruuid_fkey");

            builder.HasOne(d => d.CPUSocket)
                .WithMany()
                .HasForeignKey(d => d.CPUSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motherboardchipset_cpusocketuuid_fkey");

            //builder.HasData(new List<MotherboardChipset>()
            //{
            //    new MotherboardChipset() { UUID = Guid.NewGuid(), }
            //});
        }
    }
}
