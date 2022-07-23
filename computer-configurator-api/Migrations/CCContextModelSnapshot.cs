﻿// <auto-generated />
using System;
using ComputerConfigurator.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComputerConfigurator.Api.Migrations
{
    [DbContext(typeof(CCContext))]
    partial class CCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ComputerConfigurator.Api.Account.Account", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("salt");

                    b.Property<DateTime>("TimestampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("timestampcreated")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");

                    b.HasKey("UUID")
                        .HasName("account_pkey");

                    b.HasIndex(new[] { "Email" }, "account_email_unique")
                        .IsUnique();

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.CPUSocket.CPUSocket", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("version");

                    b.HasKey("UUID")
                        .HasName("cpusocket_pkey");

                    b.HasIndex(new[] { "Version" }, "cpusocket_version_unique")
                        .IsUnique();

                    b.ToTable("cpusocket", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.Manufacturer.Manufacturer", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("UUID")
                        .HasName("manufacturer_pkey");

                    b.HasIndex(new[] { "Name" }, "manufacturer_name_unique")
                        .IsUnique();

                    b.ToTable("manufacturer", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.Part.Part", b =>
                {
                    b.Property<Guid>("UUID")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("longdescription");

                    b.Property<Guid>("ManufacturerUUID")
                        .HasColumnType("uuid")
                        .HasColumnName("manufactureruuid");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("model");

                    b.Property<decimal>("Price")
                        .HasPrecision(7, 2)
                        .HasColumnType("numeric(7,2)")
                        .HasColumnName("price");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("shortdescription");

                    b.HasKey("UUID")
                        .HasName("part_pkey");

                    b.HasIndex(new[] { "ManufacturerUUID", "Model" }, "part_manufacturer_model_unique")
                        .IsUnique();

                    b.ToTable("part", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.Session.Session", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("key")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AccountUUID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LoginTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("logintimestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");

                    b.Property<DateTime?>("LogoutTimestamp")
                        .HasColumnType("timestamptz")
                        .HasColumnName("logouttimestamp");

                    b.HasKey("Key")
                        .HasName("session_pkey");

                    b.HasIndex("AccountUUID");

                    b.ToTable("session", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.CPU.CPU", b =>
                {
                    b.HasBaseType("ComputerConfigurator.Api.Part.Part");

                    b.Property<int>("BaseClockSpeed")
                        .HasColumnType("integer")
                        .HasColumnName("baseclockspeed");

                    b.Property<int?>("BoostClockSpeed")
                        .HasColumnType("integer")
                        .HasColumnName("boostclockspeed");

                    b.Property<Guid>("CPUSocketUUID")
                        .HasColumnType("uuid");

                    b.Property<int>("CoreCount")
                        .HasColumnType("integer")
                        .HasColumnName("corecount");

                    b.Property<int>("ThreadCount")
                        .HasColumnType("integer")
                        .HasColumnName("threadcount");

                    b.HasIndex("CPUSocketUUID");

                    b.ToTable("cpu", (string)null);
                });

            modelBuilder.Entity("ComputerConfigurator.Api.Part.Part", b =>
                {
                    b.HasOne("ComputerConfigurator.Api.Manufacturer.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerUUID")
                        .IsRequired()
                        .HasConstraintName("part_manufactureruuid_fkey");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("ComputerConfigurator.Api.Session.Session", b =>
                {
                    b.HasOne("ComputerConfigurator.Api.Account.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountUUID")
                        .IsRequired()
                        .HasConstraintName("session_accountuuid_fkey");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ComputerConfigurator.Api.CPU.CPU", b =>
                {
                    b.HasOne("ComputerConfigurator.Api.CPUSocket.CPUSocket", "CPUSocket")
                        .WithMany()
                        .HasForeignKey("CPUSocketUUID")
                        .IsRequired()
                        .HasConstraintName("cpu_cpusocketuuid_fkey");

                    b.HasOne("ComputerConfigurator.Api.Part.Part", "Part")
                        .WithOne()
                        .HasForeignKey("ComputerConfigurator.Api.CPU.CPU", "UUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("cpu_uuid_fkey");

                    b.Navigation("CPUSocket");

                    b.Navigation("Part");
                });
#pragma warning restore 612, 618
        }
    }
}
