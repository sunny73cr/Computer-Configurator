using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.RAM
{
    public class RAMConfiguration : IEntityTypeConfiguration<RAM>
    {
        public void Configure(EntityTypeBuilder<RAM> builder)
        {
            builder.ToTable("ram");

            builder.Property(x => x.RAMSocketUUID)
                .HasColumnName("ramsocketuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.RAMSpeedUUID)
                .HasColumnName("ramspeeduuid")
                .HasColumnType("uuid");

            builder.Property(x => x.ModuleCapacityGBytes)
                .HasColumnName("modulecapacitygbytes")
                .HasColumnType("integer");

            builder.Property(x => x.DIMMCount)
                .HasColumnName("dimmcount")
                .HasColumnType("integer");

            builder.Property(x => x.CAS)
                .HasColumnName("cas")
                .HasColumnType("integer");

            builder.Property(x => x.TRCD)
                .HasColumnName("trcd")
                .HasColumnType("integer");

            builder.Property(x => x.TRP)
                .HasColumnName("trp")
                .HasColumnType("integer");

            builder.Property(x => x.TRAS)
                .HasColumnName("tras")
                .HasColumnType("integer");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<RAM>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ram_uuid_fkey");

            builder.HasOne(d => d.RAMSocket)
                .WithMany()
                .HasForeignKey(d => d.RAMSocketUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ram_ramsocketuuid_fkey");

            builder.HasOne(d => d.RAMSpeed)
                .WithMany()
                .HasForeignKey(d => d.RAMSpeedUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ram_ramspeeduuid_fkey");
        }
    }
}
