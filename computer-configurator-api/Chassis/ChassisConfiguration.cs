using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Chassis
{
    public class ChassisConfiguration : IEntityTypeConfiguration<Chassis>
    {
        public void Configure(EntityTypeBuilder<Chassis> builder)
        {
            builder.ToTable("chassis");

            builder.Property(x => x.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(x => x.LengthMM)
                .HasColumnName("lengthmm")
                .HasColumnType("integer");
            
            builder.Property(x => x.WidthMM)
                .HasColumnName("widthmm")
                .HasColumnType("integer");

            builder.Property(x => x.HeightMM)
                .HasColumnName("heightmm")
                .HasColumnType("integer");

            builder.Property(x => x.MaxGPULengthMM)
                .HasColumnName("maxgpulengthmm")
                .HasColumnType("integer");

            builder.Property(x => x.MaxPSULengthMM)
                .HasColumnName("maxpsulengthmm")
                .HasColumnType("integer");

            builder.Property(x => x.MaxCPUCoolerHeightMM)
                .HasColumnName("maxcpucoolerheightmm")
                .HasColumnType("integer");

            builder.Property(x => x.PCIESlotCount)
                .HasColumnName("pcieslotcount")
                .HasColumnType("integer");

            builder.HasOne(x => x.Part)
                .WithOne()
                .HasForeignKey<Chassis>(x => x.UUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("chassis_uuid_fkey");
        }
    }
}
