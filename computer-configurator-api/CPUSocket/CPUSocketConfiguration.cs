using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.CPUSocket
{
    public class CPUSocketConfiguration : IEntityTypeConfiguration<CPUSocket>
    {
        public void Configure(EntityTypeBuilder<CPUSocket> builder)
        {
            builder.ToTable("cpusocket");

            builder.HasKey(e => e.UUID)
                .HasName("cpusocket_pkey");

            builder.HasIndex(e => e.Version, "cpusocket_version_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            //builder.HasData(new List<CPUSocket>()
            //{
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "AM3+" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "AM4" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "AM5" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "SP3" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "TR4" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "sTRX4" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA1155" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA2011" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA1150" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA2011-v3" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA1151" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA1200" },
            //    new CPUSocket() { UUID = Guid.NewGuid(), Version = "LGA1700" }
            //});
        }
    }
}
