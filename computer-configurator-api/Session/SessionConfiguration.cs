using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerConfigurator.Api.Session
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("session");

            builder.HasKey(e => e.Key).HasName("session_pkey");

            builder.Property(e => e.Key)
                .HasColumnName("key")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(e => e.LoginTimestamp)
                .HasColumnName("logintimestamp")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");

            builder.Property(e => e.LogoutTimestamp)
                .HasColumnName("logouttimestamp")
                .HasColumnType("timestamptz");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountUUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_accountuuid_fkey");
        }
    }
}
