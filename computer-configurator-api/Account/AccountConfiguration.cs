using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Account
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");

            builder.HasKey(e => e.UUID)
                .HasName("account_pkey");

            builder.HasIndex(e => e.Email, "account_email_unique")
                .IsUnique();

            builder.Property(e => e.UUID)
                .HasColumnName("uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(128)")
                .HasMaxLength(128);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(e => e.TimestampCreated)
                .HasColumnName("timestampcreated")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");
        }
    }
}
