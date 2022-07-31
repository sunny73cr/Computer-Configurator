using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.ChassisAudioPort
{
    public class ChassisAudioPortConfiguration : IEntityTypeConfiguration<ChassisAudioPort>
    {
        public void Configure(EntityTypeBuilder<ChassisAudioPort> builder)
        {
            builder.ToTable("chassis_audioport");

            builder.HasKey(e => new { e.ChassisUUID, e.AudioPortUUID, e.ChassisZoneUUID })
                .HasName("chassis_audioport_pkey");

            builder.Property(x => x.ChassisUUID)
                .HasColumnName("chassisuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.AudioPortUUID)
                .HasColumnName("audiportuuid")
                .HasColumnType("uuid");

            builder.Property(x => x.ChassisZoneUUID)
                .HasColumnName("chassiszoneuuid")
                .HasColumnType("uuid");

            builder.HasOne(d => d.Chassis)
                .WithMany(p => p.AudioPorts)
                .HasForeignKey(d => d.ChassisUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_audioport_chassisuuid_fkey");

            builder.HasOne(d => d.AudioPort)
                .WithMany()
                .HasForeignKey(d => d.AudioPortUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_audioport_audioportuuid_fkey");

            builder.HasOne(d => d.ChassisZone)
                .WithMany()
                .HasForeignKey(d => d.ChassisZoneUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chassis_audioport_chassiszoneuuid_fkey");
        }
    }
}
