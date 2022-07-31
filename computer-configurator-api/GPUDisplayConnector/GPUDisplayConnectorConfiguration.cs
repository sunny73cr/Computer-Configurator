using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.GPUDisplayConnector
{
    public class GPUDisplayConnectorConfiguration : IEntityTypeConfiguration<GPUDisplayConnector>
    {
        public void Configure(EntityTypeBuilder<GPUDisplayConnector> builder)
        {
            builder.ToTable("gpu_displayconnector");

            builder.HasKey(x => new { x.GPUUUID, x.DisplayConnectorUUID })
                .HasName("gpu_displayconnector_pkey");

            builder.Property(e => e.GPUUUID)
                .HasColumnName("gpuuuid")
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(x => x.DisplayConnectorUUID)
                .HasColumnName("displayconnectoruuid")
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(x => x.Count)
                .HasColumnName("count")
                .HasColumnType("integer");

            builder.HasOne(d => d.DisplayConnector)
                .WithMany()
                .HasForeignKey(d => d.DisplayConnectorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gpu_displayconnector_displayconnectoruuid_fkey");

            builder.HasOne(d => d.GPU)
                .WithMany(x => x.DisplayConnectors)
                .HasForeignKey(d => d.GPUUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gpu_displayconnector_gpuuuid_fkey");
        }
    }
}
