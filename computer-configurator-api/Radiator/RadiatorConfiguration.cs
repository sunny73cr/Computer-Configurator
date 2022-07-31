using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Radiator
{
    public class RadiatorConfiguration : IEntityTypeConfiguration<Radiator>
    {
        public void Configure(EntityTypeBuilder<Radiator> builder)
        {
            builder.ToTable("radiator");

            builder.Property(x => x.WidthMM)
                .HasColumnName("widthmm")
                .HasColumnType("integer");

            builder.Property(x => x.RadiatorSizeUUID)
                .HasColumnName("radiatorsizeuuid")
                .HasColumnType("integer");

            builder.Property(x => x.TubeInnerDiameterMM)
                .HasColumnName("tubeinnerdiametermm")
                .HasColumnType("real");

            builder.Property(x => x.TubeOuterDiameterMM)
                .HasColumnName("tubeouterdiametermm")
                .HasColumnType("real");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<Radiator>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("radiator_uuid_fkey");

            builder.HasOne(d => d.RadiatorSize)
                .WithMany()
                .HasForeignKey(d => d.RadiatorSizeUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("radiator_radiatorsizeuuid_fkey");
        }
    }
}
