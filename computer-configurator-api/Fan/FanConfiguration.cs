using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Fan
{
    public class FanConfiguration : IEntityTypeConfiguration<Fan>
    {
        public void Configure(EntityTypeBuilder<Fan> builder)
        {
            builder.ToTable("fan");

            builder.Property(x => x.WidthMM)
                .HasColumnName("widthmm")
                .HasColumnType("integer");
            
            builder.Property(x => x.MinRPM)
                .HasColumnName("minrpm")
                .HasColumnType("integer");

            builder.Property(x => x.MaxRPM)
                .HasColumnName("maxrpm")
                .HasColumnType("integer");

            builder.Property(x => x.MinAirflow)
                .HasColumnName("minairflow")
                .HasColumnType("real");

            builder.Property(x => x.MaxAirflow)
                .HasColumnName("maxairflow")
                .HasColumnType("real");

            builder.Property(x => x.MinStaticPressure)
                .HasColumnName("minstaticpressure")
                .HasColumnType("real");

            builder.Property(x => x.MaxStaticPressure)
                .HasColumnName("maxstaticpressure")
                .HasColumnType("real");

            builder.Property(x => x.MinAcousticOutput)
                .HasColumnName("minacousticoutput")
                .HasColumnType("real");

            builder.Property(x => x.MaxAcousticOutput)
                .HasColumnName("maxacousticoutput")
                .HasColumnType("real");

            builder.Property(x => x.MaxCurrent)
                .HasColumnName("maxcurrent")
                .HasColumnType("real");

            builder.Property(x => x.MTBFHours)
                .HasColumnName("mtbfhours")
                .HasColumnType("integer");

            builder.HasOne(d => d.FanDiameter)
                .WithMany()
                .HasForeignKey(d => d.FanDiameterUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fan_fandiameteruuid_fkey");

            builder.HasOne(d => d.FanVoltage)
                .WithMany()
                .HasForeignKey(d => d.FanVoltageUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fan_fanvoltageuuid_fkey");

            builder.HasOne(d => d.Part)
                .WithOne()
                .HasForeignKey<Fan>(d => d.UUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fan_uuid_fkey");
        }
    }
}
