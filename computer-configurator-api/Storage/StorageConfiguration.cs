using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Storage
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.ToTable("storage");

            builder.Property(x => x.CapacityGBytes)
                .HasColumnName("capacitygbytes")
                .HasColumnType("integer");

            builder.Property(x => x.ReadBandwidth)
                .HasColumnName("readbandwidth")
                .HasColumnType("integer");

            builder.Property(x => x.WriteBandwidth)
                .HasColumnName("writebandwidth")
                .HasColumnType("integer");

            builder.Property(x => x.ReadIOPS)
                .HasColumnName("readiops")
                .HasColumnType("integer");

            builder.Property(x => x.WriteIOPS)
                .HasColumnName("writeiops")
                .HasColumnType("integer");

            builder.Property(x => x.MTBF)
                .HasColumnName("mtbf")
                .HasColumnType("integer");

            builder.Property(x => x.MaxTBW)
                .HasColumnName("maxtbw")
                .HasColumnType("integer");

            builder.Property(x => x.CacheSizeMBytes)
                .HasColumnName("cachesizembytes")
                .HasColumnType("integer");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<Storage>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("storage_uuid_fkey");
        }
    }
}
