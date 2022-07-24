using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerConfigurator.Api.Migrations
{
    public partial class Scaffold_LookupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audioport",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    pincount = table.Column<int>(type: "integer", nullable: false),
                    connectorsize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audioport_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "benchmarkedresolution",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    pixelwidth = table.Column<int>(type: "integer", nullable: false),
                    pixelheight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("benchmarkedresolution_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "chassiszone",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    zone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chassiszone_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "displayconnector",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    @interface = table.Column<string>(name: "interface", type: "varchar(15)", maxLength: 15, nullable: false),
                    version = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("displayconnector_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "eightyplusrating",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    rating = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("eightyplusrating_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "ethernetport",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    chipset = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bandwidthmbytes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ethernetport_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "fandiameter",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    diameter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fandiameter_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "fanheader",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    pincount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fanheader_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "fanvoltage",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    fanvoltage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fanvoltage_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "motherboardchipset",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    manufactureruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    cpusocketuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    version = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboardchipset_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "motherboardchipset_cpusocketuuid_fkey",
                        column: x => x.cpusocketuuid,
                        principalTable: "cpusocket",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboardchipset_manufactureruuid_fkey",
                        column: x => x.manufactureruuid,
                        principalTable: "manufacturer",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboardformfactor",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    formfactor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboardformfactor_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "mountedstorageformfactor",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    size = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mountedstorageformfactor_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "nvmeformfactor",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    formfactor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("nvmeformfactor_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "nvmeinterface",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    @interface = table.Column<string>(name: "interface", type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("nvmeinterface_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "pciegeneration",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    generation = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pciegeneration_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "powersupplyformfactor",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    formfactor = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("powersupplyformfactor_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "radiatorsize",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("radiatorsize_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "raidmode",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    mode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("raidmode_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "ramsocket",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    version = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ramsocket_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "ramspeed",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    clockrate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ramspeed_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "satageneration",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    generation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("satageneration_pkey", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "usbport",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    @interface = table.Column<string>(name: "interface", type: "varchar(15)", maxLength: 15, nullable: false),
                    version = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usbport_pkey", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "pcieconnector",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PCIEGenerationUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    lanecount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pcieconnector_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "pcieconnector_pciegenerationuuid_fkey",
                        column: x => x.PCIEGenerationUUID,
                        principalTable: "pciegeneration",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_audioport_pincount_connectorsize",
                table: "audioport",
                columns: new[] { "pincount", "connectorsize" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "benchmarkedresolution_pixelarea_unique",
                table: "benchmarkedresolution",
                columns: new[] { "pixelwidth", "pixelheight" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "chassiszone_zone_unique",
                table: "chassiszone",
                column: "zone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "displayconnector_interface_version_unique",
                table: "displayconnector",
                columns: new[] { "interface", "version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "eightyplusrating_rating_unique",
                table: "eightyplusrating",
                column: "rating",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fandiameter_diameter_unique",
                table: "fandiameter",
                column: "diameter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fanheader_pincount_unique",
                table: "fanheader",
                column: "pincount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fanvoltage_voltage_unique",
                table: "fanvoltage",
                column: "fanvoltage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_motherboardchipset_cpusocketuuid",
                table: "motherboardchipset",
                column: "cpusocketuuid");

            migrationBuilder.CreateIndex(
                name: "motherboardchipset_manufacturer_version_unique",
                table: "motherboardchipset",
                columns: new[] { "manufactureruuid", "version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "motherboardformfactor_formfactor_unique",
                table: "motherboardformfactor",
                column: "formfactor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "mountedstorageformfactor_size_unique",
                table: "mountedstorageformfactor",
                column: "size",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "nvmeformfactor_formfactor_unique",
                table: "nvmeformfactor",
                column: "formfactor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "nvminterface_interface_unique",
                table: "nvmeinterface",
                column: "interface",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "pcieconnector_lanecount_unique",
                table: "pcieconnector",
                columns: new[] { "PCIEGenerationUUID", "lanecount" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "pciegeneration_generation_unique",
                table: "pciegeneration",
                column: "generation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "powersupplyformfactor_formfactor_unique",
                table: "powersupplyformfactor",
                column: "formfactor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "radiatorsize_size_unique",
                table: "radiatorsize",
                column: "size",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "raidmode_mode_unique",
                table: "raidmode",
                column: "mode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ramsocket_version_unique",
                table: "ramsocket",
                column: "version",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ramspeed_clockrate_unique",
                table: "ramspeed",
                column: "clockrate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "satageneration_generation_unique",
                table: "satageneration",
                column: "generation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "usbport_interface_version_unique",
                table: "usbport",
                columns: new[] { "interface", "version" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audioport");

            migrationBuilder.DropTable(
                name: "benchmarkedresolution");

            migrationBuilder.DropTable(
                name: "chassiszone");

            migrationBuilder.DropTable(
                name: "displayconnector");

            migrationBuilder.DropTable(
                name: "eightyplusrating");

            migrationBuilder.DropTable(
                name: "ethernetport");

            migrationBuilder.DropTable(
                name: "fandiameter");

            migrationBuilder.DropTable(
                name: "fanheader");

            migrationBuilder.DropTable(
                name: "fanvoltage");

            migrationBuilder.DropTable(
                name: "motherboardchipset");

            migrationBuilder.DropTable(
                name: "motherboardformfactor");

            migrationBuilder.DropTable(
                name: "mountedstorageformfactor");

            migrationBuilder.DropTable(
                name: "nvmeformfactor");

            migrationBuilder.DropTable(
                name: "nvmeinterface");

            migrationBuilder.DropTable(
                name: "pcieconnector");

            migrationBuilder.DropTable(
                name: "powersupplyformfactor");

            migrationBuilder.DropTable(
                name: "radiatorsize");

            migrationBuilder.DropTable(
                name: "raidmode");

            migrationBuilder.DropTable(
                name: "ramsocket");

            migrationBuilder.DropTable(
                name: "ramspeed");

            migrationBuilder.DropTable(
                name: "satageneration");

            migrationBuilder.DropTable(
                name: "usbport");

            migrationBuilder.DropTable(
                name: "pciegeneration");
        }
    }
}
