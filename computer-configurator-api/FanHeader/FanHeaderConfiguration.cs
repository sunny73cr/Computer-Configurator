using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.FanHeader
{
    public class FanHeaderConfiguration : IEntityTypeConfiguration<FanHeader>
    {
        public void Configure(EntityTypeBuilder<FanHeader> builder)
        {
            builder.ToTable("fanheader");

            builder.HasKey(e => e.UUID)
                .HasName("fanheader_pkey");

            builder.HasIndex(e => e.PinCount, "fanheader_pincount_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.PinCount)
                .HasColumnName("pincount")
                .HasColumnType("integer");

            //builder.HasData(new List<FanHeader>()
            //{
            //    new FanHeader() { UUID = Guid.NewGuid(), PinCount = 3 },
            //    new FanHeader() { UUID = Guid.NewGuid(), PinCount = 4 }
            //});
        }
    }
}
