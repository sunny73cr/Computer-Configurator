using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUCooler
{
    public class CPUCoolerConfiguration : IEntityTypeConfiguration<CPUCooler>
    {
        public void Configure(EntityTypeBuilder<CPUCooler> builder)
        {
            builder.ToTable("cpucooler");

            builder.Property(x => x.TDPRating)
                .HasColumnName("tdprating")
                .HasColumnType("integer");

            builder.HasOne(x => x.Part)
                .WithOne()
                .HasForeignKey<CPUCooler>(x => x.UUID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cpucooler_uuid_fkey");
        }
    }
}
