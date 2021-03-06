using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.EightyPlusRating
{
    public class EightyPlusRatingConfiguration : IEntityTypeConfiguration<EightyPlusRating>
    {
        public void Configure(EntityTypeBuilder<EightyPlusRating> builder)
        {
            builder.ToTable("eightyplusrating");

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

            //builder.HasData(new List<EightyPlusRating>()
            //{
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "White" },
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "Bronze" },
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "Silver" },
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "Gold" },
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "Titanium" },
            //    new EightyPlusRating() { UUID = Guid.NewGuid(), Rating = "Platinum" }
            //});
        }
    }
}
