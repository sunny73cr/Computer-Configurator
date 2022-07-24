using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.AudioPort
{
    public class AudioPortConfiguration : IEntityTypeConfiguration<AudioPort>
    {
        public void Configure(EntityTypeBuilder<AudioPort> builder)
        {
            builder.ToTable("audioport");

            builder.HasKey(e => e.UUID)
                .HasName("audioport_pkey");

            builder.HasIndex(x => new { x.PinCount, x.ConnectorSize })
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.PinCount)
                .HasColumnName("pincount")
                .HasColumnType("integer");

            builder.Property(e => e.ConnectorSize)
                .HasColumnName("connectorsize")
                .HasColumnType("integer");
        }
    }
}
