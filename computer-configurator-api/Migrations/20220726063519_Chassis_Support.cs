using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerConfigurator.Api.Migrations
{
    public partial class Chassis_Support : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chassis",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    lengthmm = table.Column<int>(type: "integer", nullable: false),
                    widthmm = table.Column<int>(type: "integer", nullable: false),
                    heightmm = table.Column<int>(type: "integer", nullable: false),
                    maxgpulengthmm = table.Column<int>(type: "integer", nullable: false),
                    maxpsulengthmm = table.Column<int>(type: "integer", nullable: false),
                    maxcpucoolerheightmm = table.Column<int>(type: "integer", nullable: false),
                    pcieslotcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "chassis_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chassis_audioport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    audiportuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    chassiszoneuuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_audioport_pkey", x => new { x.chassisuuid, x.audiportuuid, x.chassiszoneuuid });
                    table.ForeignKey(
                        name: "chassis_audioport_audioportuuid_fkey",
                        column: x => x.audiportuuid,
                        principalTable: "audioport",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_audioport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_audioport_chassiszoneuuid_fkey",
                        column: x => x.chassiszoneuuid,
                        principalTable: "chassiszone",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_fansupport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    fandiameteruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    chassiszoneuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    maximumwidthmm = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_fansupport_pkey", x => new { x.chassisuuid, x.fandiameteruuid, x.chassiszoneuuid });
                    table.ForeignKey(
                        name: "chassis_fansupport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_fansupport_chassiszoneuuid_fkey",
                        column: x => x.chassiszoneuuid,
                        principalTable: "chassiszone",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_fansupport_fandiameteruuid_fkey",
                        column: x => x.fandiameteruuid,
                        principalTable: "fandiameter",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_filtersupport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    chassiszoneuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    removeable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_filtersupport_pkey", x => new { x.chassisuuid, x.chassiszoneuuid });
                    table.ForeignKey(
                        name: "chassis_filtersupport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_filtersupport_chassiszoneuuid_fkey",
                        column: x => x.chassiszoneuuid,
                        principalTable: "chassiszone",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_motherboardformfactorsupport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    motherboardformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_motherboardformfactorsupport_pkey", x => new { x.chassisuuid, x.motherboardformfactoruuid });
                    table.ForeignKey(
                        name: "chassis_motherboardformfactorsupport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_motherboardformfactorsupport_motherboardformfactoruuis_fkey",
                        column: x => x.motherboardformfactoruuid,
                        principalTable: "motherboardformfactor",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_powersupplyformfactorsupport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    powersupplyformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    bracketrequired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_powersupplyformfactorsupport_pkey", x => new { x.chassisuuid, x.powersupplyformfactoruuid });
                    table.ForeignKey(
                        name: "chassis_powersupplyformfactorsupport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_powersupplyformfactorsupport_psuformfactoruuid_fkey",
                        column: x => x.powersupplyformfactoruuid,
                        principalTable: "powersupplyformfactor",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_radiatorsupport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    radiatorsizeuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    chassiszoneuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    maximumwidthmm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_radiatorsupport_pkey", x => new { x.chassisuuid, x.radiatorsizeuuid, x.chassiszoneuuid });
                    table.ForeignKey(
                        name: "chassis_radiatorsupport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_radiatorsupport_chassiszoneuuid_fkey",
                        column: x => x.chassiszoneuuid,
                        principalTable: "chassiszone",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_radiatorsupport_radiatorsizeuuid_fkey",
                        column: x => x.radiatorsizeuuid,
                        principalTable: "radiatorsize",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "chassis_usbport",
                columns: table => new
                {
                    chassisuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    usbportuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    chassiszoneuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassis_usbport_pkey", x => new { x.chassisuuid, x.usbportuuid, x.chassiszoneuuid });
                    table.ForeignKey(
                        name: "chassis_usbport_chassisuuid_fkey",
                        column: x => x.chassisuuid,
                        principalTable: "chassis",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_usbport_chassiszoneuuid_fkey",
                        column: x => x.chassiszoneuuid,
                        principalTable: "chassiszone",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "chassis_usbport_usbportuuid_fkey",
                        column: x => x.usbportuuid,
                        principalTable: "usbport",
                        principalColumn: "UUID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chassis_audioport_audiportuuid",
                table: "chassis_audioport",
                column: "audiportuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_audioport_chassiszoneuuid",
                table: "chassis_audioport",
                column: "chassiszoneuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_fansupport_chassiszoneuuid",
                table: "chassis_fansupport",
                column: "chassiszoneuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_fansupport_fandiameteruuid",
                table: "chassis_fansupport",
                column: "fandiameteruuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_filtersupport_chassiszoneuuid",
                table: "chassis_filtersupport",
                column: "chassiszoneuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_motherboardformfactorsupport_motherboardformfactoru~",
                table: "chassis_motherboardformfactorsupport",
                column: "motherboardformfactoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_powersupplyformfactorsupport_powersupplyformfactoru~",
                table: "chassis_powersupplyformfactorsupport",
                column: "powersupplyformfactoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_radiatorsupport_chassiszoneuuid",
                table: "chassis_radiatorsupport",
                column: "chassiszoneuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_radiatorsupport_radiatorsizeuuid",
                table: "chassis_radiatorsupport",
                column: "radiatorsizeuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_usbport_chassiszoneuuid",
                table: "chassis_usbport",
                column: "chassiszoneuuid");

            migrationBuilder.CreateIndex(
                name: "IX_chassis_usbport_usbportuuid",
                table: "chassis_usbport",
                column: "usbportuuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chassis_audioport");

            migrationBuilder.DropTable(
                name: "chassis_fansupport");

            migrationBuilder.DropTable(
                name: "chassis_filtersupport");

            migrationBuilder.DropTable(
                name: "chassis_motherboardformfactorsupport");

            migrationBuilder.DropTable(
                name: "chassis_powersupplyformfactorsupport");

            migrationBuilder.DropTable(
                name: "chassis_radiatorsupport");

            migrationBuilder.DropTable(
                name: "chassis_usbport");

            migrationBuilder.DropTable(
                name: "chassis");
        }
    }
}
