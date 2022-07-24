using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.RAMSpeed
{
    public class RAMSpeedConfiguration : IEntityTypeConfiguration<RAMSpeed>
    {
        public void Configure(EntityTypeBuilder<RAMSpeed> builder)
        {
            builder.ToTable("ramspeed");

            builder.HasKey(e => e.UUID)
                .HasName("ramspeed_pkey");

            builder.HasIndex(e => e.ClockRate, "ramspeed_clockrate_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.ClockRate)
                .HasColumnName("clockrate")
                .HasColumnType("integer");
        }
    }
}
