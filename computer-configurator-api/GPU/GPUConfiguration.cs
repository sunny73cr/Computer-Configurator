using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.GPU
{
    public class GPUConfiguration : IEntityTypeConfiguration<GPU>
    {
        public void Configure(EntityTypeBuilder<GPU> builder)
        {
            builder.ToTable("gpu");

            builder.Property(x => x.PCIEConnectorUUID)
                .HasColumnName("pcieconnectoruuid")
                .HasColumnType("uuid");

            builder.Property(x => x.VRAMMBytes)
                .HasColumnName("vrammbytes")
                .HasColumnType("integer");

            builder.Property(x => x.BaseClockSpeed)
                .HasColumnName("baseclockspeed")
                .HasColumnType("integer");

            builder.Property(x => x.BoostClockSpeed)
                .HasColumnName("boostclockspeed")
                .HasColumnType("integer");

            builder.Property(x => x.MaxDisplayCount)
                .HasColumnName("maxdisplaycount")
                .HasColumnType("integer");

            builder.Property(x => x.LengthMM)
                .HasColumnName("lengthmm")
                .HasColumnType("integer");

            builder.Property(x => x.WidthMM)
                .HasColumnName("widthmm")
                .HasColumnType("integer");

            builder.Property(x => x.HeightMM)
                .HasColumnName("heightmm")
                .HasColumnType("integer");

            builder.Property(x => x.SlotWidth)
                .HasColumnName("slotwidth")
                .HasColumnType("real");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<GPU>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gpu_uuid_fkey");

            builder.HasOne(d => d.PCIEConnector)
                .WithMany()
                .HasForeignKey(d => d.PCIEConnectorUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gpu_pcieconnectoruuid_fkey");
        }
    }
}
