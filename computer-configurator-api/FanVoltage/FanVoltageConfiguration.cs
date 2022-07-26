using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.FanVoltage
{
    public class FanVoltageConfiguration : IEntityTypeConfiguration<FanVoltage>
    {
        public void Configure(EntityTypeBuilder<FanVoltage> builder)
        {
            builder.ToTable("fanvoltage");

            builder.HasKey(e => e.UUID)
                .HasName("fanvoltage_pkey");

            builder.HasIndex(e => e.Voltage, "fanvoltage_voltage_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Voltage)
                .HasColumnName("fanvoltage")
                .HasColumnType("real");

            //builder.HasData(new List<FanVoltage>()
            //{
            //    new FanVoltage() { UUID = Guid.NewGuid(), Voltage = 3.3f },
            //    new FanVoltage() { UUID = Guid.NewGuid(), Voltage = 5f },
            //    new FanVoltage() { UUID = Guid.NewGuid(), Voltage = 12f },
            //    new FanVoltage() { UUID = Guid.NewGuid(), Voltage = 24f },
            //});
        }
    }
}
