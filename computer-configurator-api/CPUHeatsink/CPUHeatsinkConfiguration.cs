using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUHeatsink
{
    public class CPUHeatsinkConfiguration : IEntityTypeConfiguration<CPUHeatsink>
    {
        public void Configure(EntityTypeBuilder<CPUHeatsink> builder)
        {
            builder.ToTable("cpucooler");

            builder.Property(x => x.HeightMM)
                .HasColumnName("heightmm")
                .HasColumnType("integer");

            builder.HasOne(d => d.CPUCooler)
                .WithOne()
                .HasForeignKey<CPUHeatsink>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cpuheatsink_uuid_fkey");
        }
    }
}
