using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerConfigurator.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    salt = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    timestampcreated = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "cpusocket",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpusocket_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("manufacturer_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    key = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AccountUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    logintimestamp = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(3)"),
                    logouttimestamp = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("session_pkey", x => x.key);
                    table.ForeignKey(
                        name: "session_accountuuid_fkey",
                        column: x => x.AccountUUID,
                        principalTable: "account",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "part",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ManufacturerUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    shortdescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    longdescription = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    price = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("part_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "part_manufactureruuid_fkey",
                        column: x => x.ManufacturerUUID,
                        principalTable: "manufacturer",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "cpu",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CPUSocketUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    corecount = table.Column<int>(type: "integer", nullable: false),
                    threadcount = table.Column<int>(type: "integer", nullable: false),
                    baseclockspeed = table.Column<int>(type: "integer", nullable: false),
                    boostclockspeed = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpu_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "cpu_cpusocketuuid_fkey",
                        column: x => x.CPUSocketUUID,
                        principalTable: "cpusocket",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "cpu_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateIndex(
                name: "account_email_unique",
                table: "account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cpu_CPUSocketUUID",
                table: "cpu",
                column: "CPUSocketUUID");

            migrationBuilder.CreateIndex(
                name: "cpusocket_version_unique",
                table: "cpusocket",
                column: "version",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "manufacturer_name_unique",
                table: "manufacturer",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "part_manufacturer_model_unique",
                table: "part",
                columns: new[] { "ManufacturerUUID", "model" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_session_AccountUUID",
                table: "session",
                column: "AccountUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cpu");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "cpusocket");

            migrationBuilder.DropTable(
                name: "part");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "manufacturer");
        }
    }
}
