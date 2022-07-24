using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.EightyPlusRating
{
    public class EightyPlusRatingConfiguration : IEntityTypeConfiguration<EightyPlusRating>
    {
        public void Configure(EntityTypeBuilder<EightyPlusRating> builder)
        {
            builder.HasKey(e => e.UUID)
                .HasName("eightyplusrating_pkey");

            builder.HasIndex(e => e.Rating, "eightyplusrating_rating_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Rating)
                .HasColumnName("rating")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
        }
    }
}
