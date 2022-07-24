using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.MountedStorageFormFactor
{
    public class MountedStorageFormFactorConfiguration : IEntityTypeConfiguration<MountedStorageFormFactor>
    {
        public void Configure(EntityTypeBuilder<MountedStorageFormFactor> builder)
        {
            builder.ToTable("mountedstorageformfactor");

            builder.HasKey(e => e.UUID)
                .HasName("mountedstorageformfactor_pkey");

            builder.HasIndex(e => e.Size, "mountedstorageformfactor_size_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
