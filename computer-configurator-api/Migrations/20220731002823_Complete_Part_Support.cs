using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerConfigurator.Api.Migrations
{
    public partial class Complete_Part_Support : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "chassis_motherboardformfactorsupport_motherboardformfactoruuis_fkey",
                table: "chassis_motherboardformfactorsupport");

            migrationBuilder.RenameIndex(
                name: "IX_audioport_pincount_connectorsize",
                table: "audioport",
                newName: "audioport_pincount_connectorsize_unique");

            migrationBuilder.AlterColumn<float>(
                name: "fanvoltage",
                table: "fanvoltage",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "cpucooler",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    tdprating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpucooler_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "cpucooler_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fan",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    FanDiameterUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    widthmm = table.Column<int>(type: "integer", nullable: false),
                    PWMSupport = table.Column<bool>(type: "boolean", nullable: false),
                    minrpm = table.Column<int>(type: "integer", nullable: false),
                    maxrpm = table.Column<int>(type: "integer", nullable: false),
                    minairflow = table.Column<float>(type: "real", nullable: false),
                    maxairflow = table.Column<float>(type: "real", nullable: false),
                    minstaticpressure = table.Column<float>(type: "real", nullable: false),
                    maxstaticpressure = table.Column<float>(type: "real", nullable: false),
                    minacousticoutput = table.Column<float>(type: "real", nullable: false),
                    maxacousticoutput = table.Column<float>(type: "real", nullable: false),
                    FanVoltageUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    maxcurrent = table.Column<float>(type: "real", nullable: false),
                    mtbfhours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fan_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "fan_fandiameteruuid_fkey",
                        column: x => x.FanDiameterUUID,
                        principalTable: "fandiameter",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "fan_fanvoltageuuid_fkey",
                        column: x => x.FanVoltageUUID,
                        principalTable: "fanvoltage",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "fan_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "gpu",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    pcieconnectoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    vrammbytes = table.Column<int>(type: "integer", nullable: false),
                    baseclockspeed = table.Column<int>(type: "integer", nullable: false),
                    boostclockspeed = table.Column<int>(type: "integer", nullable: true),
                    maxdisplaycount = table.Column<int>(type: "integer", nullable: false),
                    lengthmm = table.Column<int>(type: "integer", nullable: false),
                    widthmm = table.Column<int>(type: "integer", nullable: false),
                    heightmm = table.Column<int>(type: "integer", nullable: false),
                    slotwidth = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gpu_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "gpu_pcieconnectoruuid_fkey",
                        column: x => x.pcieconnectoruuid,
                        principalTable: "pcieconnector",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "gpu_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CPUSocketUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    CPUSocketCount = table.Column<int>(type: "integer", nullable: false),
                    MotherboardFormFactorUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    MotherboardChipsetUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    WifiSupport = table.Column<bool>(type: "boolean", nullable: false),
                    MaxRAMCapacityMByte = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "motherboard_cpusocketuuid_fkey",
                        column: x => x.CPUSocketUUID,
                        principalTable: "cpusocket",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_motherboardchipsetuuid_fkey",
                        column: x => x.MotherboardChipsetUUID,
                        principalTable: "motherboardchipset",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_motherboardformfactoruuid_fkey",
                        column: x => x.MotherboardFormFactorUUID,
                        principalTable: "motherboardformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "powersupply",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    maximumoutputwatts = table.Column<int>(type: "integer", nullable: false),
                    powersupplyformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    lengthmm = table.Column<int>(type: "integer", nullable: false),
                    modularcables = table.Column<bool>(type: "boolean", nullable: false),
                    mtbf = table.Column<int>(type: "integer", nullable: true),
                    eightyplusratinguuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("powersupply_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "powersupply_eightyplusratinguuid_fkey",
                        column: x => x.eightyplusratinguuid,
                        principalTable: "eightyplusrating",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "powersupply_powersupplyformfactoruuid_fkey",
                        column: x => x.powersupplyformfactoruuid,
                        principalTable: "powersupplyformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "powersupply_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "radiator",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    widthmm = table.Column<int>(type: "integer", nullable: false),
                    radiatorsizeuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    tubeinnerdiametermm = table.Column<float>(type: "real", nullable: false),
                    tubeouterdiametermm = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("radiator_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "radiator_radiatorsizeuuid_fkey",
                        column: x => x.radiatorsizeuuid,
                        principalTable: "radiatorsize",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "radiator_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "ram",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ramsocketuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ramspeeduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    modulecapacitygbytes = table.Column<int>(type: "integer", nullable: false),
                    dimmcount = table.Column<int>(type: "integer", nullable: false),
                    cas = table.Column<int>(type: "integer", nullable: false),
                    trcd = table.Column<int>(type: "integer", nullable: false),
                    trp = table.Column<int>(type: "integer", nullable: false),
                    tras = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ram_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "ram_ramsocketuuid_fkey",
                        column: x => x.ramsocketuuid,
                        principalTable: "ramsocket",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "ram_ramspeeduuid_fkey",
                        column: x => x.ramspeeduuid,
                        principalTable: "ramspeed",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "ram_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "storage",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    capacitygbytes = table.Column<int>(type: "integer", nullable: false),
                    readbandwidth = table.Column<int>(type: "integer", nullable: false),
                    writebandwidth = table.Column<int>(type: "integer", nullable: false),
                    readiops = table.Column<int>(type: "integer", nullable: true),
                    writeiops = table.Column<int>(type: "integer", nullable: true),
                    mtbf = table.Column<int>(type: "integer", nullable: true),
                    maxtbw = table.Column<int>(type: "integer", nullable: true),
                    cachesizembytes = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("storage_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "storage_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "part",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "cpuclosedloopcooler",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    radiatorsizeuuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpuclosedloopcooler_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "cpuclosedloopcooler_radiatorsizeuuid_fkey",
                        column: x => x.radiatorsizeuuid,
                        principalTable: "radiatorsize",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "cpuclosedloopcooler_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "cpucooler",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "cpucooler_cpusocket_support",
                columns: table => new
                {
                    cpucooleruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    cpusocketuuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpucooler_cpusocket_support_pkey", x => new { x.cpucooleruuid, x.cpusocketuuid });
                    table.ForeignKey(
                        name: "cpucooler_cpusocket_cpucooleruuid_fkey",
                        column: x => x.cpucooleruuid,
                        principalTable: "cpucooler",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "cpucooler_cpusocket_cpusocketuuid_fkey",
                        column: x => x.cpusocketuuid,
                        principalTable: "cpusocket",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "cpuheatsink",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    heightmm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpuheatsink_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "cpuheatsink_uuid_fkey",
                        column: x => x.uuid,
                        principalTable: "cpucooler",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "cpucooler_fan",
                columns: table => new
                {
                    cpucooleruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    fanuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cpucooler_fan_pkey", x => new { x.cpucooleruuid, x.fanuuid });
                    table.ForeignKey(
                        name: "cpucooler_fan_cpucooleruuid_fkey",
                        column: x => x.cpucooleruuid,
                        principalTable: "cpucooler",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "cpucooler_fan_fanuuid_fkey",
                        column: x => x.fanuuid,
                        principalTable: "fan",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gpu_displayconnector",
                columns: table => new
                {
                    gpuuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    displayconnectoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gpu_displayconnector_pkey", x => new { x.gpuuuid, x.displayconnectoruuid });
                    table.ForeignKey(
                        name: "gpu_displayconnector_displayconnectoruuid_fkey",
                        column: x => x.displayconnectoruuid,
                        principalTable: "displayconnector",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "gpu_displayconnector_gpuuuid_fkey",
                        column: x => x.gpuuuid,
                        principalTable: "gpu",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_displayconnector",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    displayconnectoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_displayconnector_pkey", x => new { x.motherboarduuid, x.displayconnectoruuid });
                    table.ForeignKey(
                        name: "motherboard_displayconnector_displayconnectoruuid_fkey",
                        column: x => x.displayconnectoruuid,
                        principalTable: "displayconnector",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_displayconnector_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "motherboard_ethernetport",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ethernetportuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_ethernetport_pkey", x => new { x.motherboarduuid, x.ethernetportuuid });
                    table.ForeignKey(
                        name: "motherboard_ethernetport_ethernetportuuid_fkey",
                        column: x => x.ethernetportuuid,
                        principalTable: "ethernetport",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_ethernetport_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "motherboard_fanheader",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    fanheaderuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_fanheader_pkey", x => new { x.motherboarduuid, x.fanheaderuuid });
                    table.ForeignKey(
                        name: "motherboard_fanheader_fanheaderuuid_fkey",
                        column: x => x.fanheaderuuid,
                        principalTable: "fanheader",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_fanheader_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "motherboard_nvmeconnector",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    pciegenerationuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nvmeinterfaceuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    nvmeformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_nvmeconnector_pkey", x => new { x.motherboarduuid, x.pciegenerationuuid, x.nvmeinterfaceuuid, x.nvmeformfactoruuid });
                    table.ForeignKey(
                        name: "motherboard_nvmeconnector_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_nvmeconnector_nvmeformfactoruuid_fkey",
                        column: x => x.nvmeformfactoruuid,
                        principalTable: "nvmeformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_nvmeconnector_nvmeinterfaceuuid_fkey",
                        column: x => x.nvmeinterfaceuuid,
                        principalTable: "nvmeinterface",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "motherboard_nvmeconnector_pciegenerationuuid_fkey",
                        column: x => x.pciegenerationuuid,
                        principalTable: "pciegeneration",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_pcieconnector",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    pcieconnectoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_pcieconnector_pkey", x => new { x.motherboarduuid, x.pcieconnectoruuid });
                    table.ForeignKey(
                        name: "motherboard_pcieconnector_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "motherboard_pcieconnector_pcieconnectoruuid_fkey",
                        column: x => x.pcieconnectoruuid,
                        principalTable: "pcieconnector",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_ramsocket",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ramsocketuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_ramsocket_pkey", x => new { x.motherboarduuid, x.ramsocketuuid });
                    table.ForeignKey(
                        name: "motherboard_ramsocket_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "motherboard_ramsocket_ramsocketuuid_fkey",
                        column: x => x.ramsocketuuid,
                        principalTable: "ramsocket",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_ramspeed",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ramspeeduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    requiresoverclock = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_ramspeed_pkey", x => new { x.motherboarduuid, x.ramspeeduuid });
                    table.ForeignKey(
                        name: "motherboard_ramspeed_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "motherboard_ramspeed_ramspeeduuid_fkey",
                        column: x => x.ramspeeduuid,
                        principalTable: "ramspeed",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_sataconnector",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    satagenerationuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_sataconnector_pkey", x => new { x.motherboarduuid, x.satagenerationuuid });
                    table.ForeignKey(
                        name: "motherboard_sataconnector_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "motherboard_sataconnector_satagenerationuuid_fkey",
                        column: x => x.satagenerationuuid,
                        principalTable: "satageneration",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "motherboard_usbport",
                columns: table => new
                {
                    motherboarduuid = table.Column<Guid>(type: "uuid", nullable: false),
                    usbportuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    InternalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("motherboard_usbport_pkey", x => new { x.motherboarduuid, x.usbportuuid });
                    table.ForeignKey(
                        name: "motherboard_usbport_motherboarduuid_fkey",
                        column: x => x.motherboarduuid,
                        principalTable: "motherboard",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "motherboard_usbport_usbportuuid_fkey",
                        column: x => x.usbportuuid,
                        principalTable: "usbport",
                        principalColumn: "UUID");
                });

            migrationBuilder.CreateTable(
                name: "nvmessd",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    NVMEFormFactorUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    NVMEInterfaceUUID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("nvmessd_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "nvmessd_nvmeformfactoruuid_fkey",
                        column: x => x.NVMEFormFactorUUID,
                        principalTable: "nvmeformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "nvmessd_nvmeinterfaceuuid_fkey",
                        column: x => x.NVMEInterfaceUUID,
                        principalTable: "nvmeinterface",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "nvmessd_storageuuid_fkey",
                        column: x => x.uuid,
                        principalTable: "storage",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "satahdd",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    mountedstorageformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    spindlerpm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("satahdd_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "satahdd_mountedstorageformfactoruuid_fkey",
                        column: x => x.mountedstorageformfactoruuid,
                        principalTable: "mountedstorageformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "satahdd_storageuuid_fkey",
                        column: x => x.uuid,
                        principalTable: "storage",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "satassd",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    mountedstorageformfactoruuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("satassd_pkey", x => x.uuid);
                    table.ForeignKey(
                        name: "satassd_mountedstorageformfactoruuid_fkey",
                        column: x => x.mountedstorageformfactoruuid,
                        principalTable: "mountedstorageformfactor",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "satassd_storageuuid_fkey",
                        column: x => x.uuid,
                        principalTable: "storage",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateIndex(
                name: "ethernetport_chipset_unique",
                table: "ethernetport",
                column: "chipset",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cpuclosedloopcooler_radiatorsizeuuid",
                table: "cpuclosedloopcooler",
                column: "radiatorsizeuuid");

            migrationBuilder.CreateIndex(
                name: "IX_cpucooler_cpusocket_support_cpusocketuuid",
                table: "cpucooler_cpusocket_support",
                column: "cpusocketuuid");

            migrationBuilder.CreateIndex(
                name: "IX_cpucooler_fan_fanuuid",
                table: "cpucooler_fan",
                column: "fanuuid");

            migrationBuilder.CreateIndex(
                name: "IX_fan_FanDiameterUUID",
                table: "fan",
                column: "FanDiameterUUID");

            migrationBuilder.CreateIndex(
                name: "IX_fan_FanVoltageUUID",
                table: "fan",
                column: "FanVoltageUUID");

            migrationBuilder.CreateIndex(
                name: "IX_gpu_pcieconnectoruuid",
                table: "gpu",
                column: "pcieconnectoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_gpu_displayconnector_displayconnectoruuid",
                table: "gpu_displayconnector",
                column: "displayconnectoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_CPUSocketUUID",
                table: "motherboard",
                column: "CPUSocketUUID");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_MotherboardChipsetUUID",
                table: "motherboard",
                column: "MotherboardChipsetUUID");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_MotherboardFormFactorUUID",
                table: "motherboard",
                column: "MotherboardFormFactorUUID");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_displayconnector_displayconnectoruuid",
                table: "motherboard_displayconnector",
                column: "displayconnectoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_ethernetport_ethernetportuuid",
                table: "motherboard_ethernetport",
                column: "ethernetportuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_fanheader_fanheaderuuid",
                table: "motherboard_fanheader",
                column: "fanheaderuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_nvmeconnector_nvmeformfactoruuid",
                table: "motherboard_nvmeconnector",
                column: "nvmeformfactoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_nvmeconnector_nvmeinterfaceuuid",
                table: "motherboard_nvmeconnector",
                column: "nvmeinterfaceuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_nvmeconnector_pciegenerationuuid",
                table: "motherboard_nvmeconnector",
                column: "pciegenerationuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_pcieconnector_pcieconnectoruuid",
                table: "motherboard_pcieconnector",
                column: "pcieconnectoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_ramsocket_ramsocketuuid",
                table: "motherboard_ramsocket",
                column: "ramsocketuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_ramspeed_ramspeeduuid",
                table: "motherboard_ramspeed",
                column: "ramspeeduuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_sataconnector_satagenerationuuid",
                table: "motherboard_sataconnector",
                column: "satagenerationuuid");

            migrationBuilder.CreateIndex(
                name: "IX_motherboard_usbport_usbportuuid",
                table: "motherboard_usbport",
                column: "usbportuuid");

            migrationBuilder.CreateIndex(
                name: "IX_nvmessd_NVMEFormFactorUUID",
                table: "nvmessd",
                column: "NVMEFormFactorUUID");

            migrationBuilder.CreateIndex(
                name: "IX_nvmessd_NVMEInterfaceUUID",
                table: "nvmessd",
                column: "NVMEInterfaceUUID");

            migrationBuilder.CreateIndex(
                name: "IX_powersupply_eightyplusratinguuid",
                table: "powersupply",
                column: "eightyplusratinguuid");

            migrationBuilder.CreateIndex(
                name: "IX_powersupply_powersupplyformfactoruuid",
                table: "powersupply",
                column: "powersupplyformfactoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_radiator_radiatorsizeuuid",
                table: "radiator",
                column: "radiatorsizeuuid");

            migrationBuilder.CreateIndex(
                name: "IX_ram_ramsocketuuid",
                table: "ram",
                column: "ramsocketuuid");

            migrationBuilder.CreateIndex(
                name: "IX_ram_ramspeeduuid",
                table: "ram",
                column: "ramspeeduuid");

            migrationBuilder.CreateIndex(
                name: "IX_satahdd_mountedstorageformfactoruuid",
                table: "satahdd",
                column: "mountedstorageformfactoruuid");

            migrationBuilder.CreateIndex(
                name: "IX_satassd_mountedstorageformfactoruuid",
                table: "satassd",
                column: "mountedstorageformfactoruuid");

            migrationBuilder.AddForeignKey(
                name: "chassis_motherboardformfactorsupport_motherboardformfactoruuid_fkey",
                table: "chassis_motherboardformfactorsupport",
                column: "motherboardformfactoruuid",
                principalTable: "motherboardformfactor",
                principalColumn: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "chassis_motherboardformfactorsupport_motherboardformfactoruuid_fkey",
                table: "chassis_motherboardformfactorsupport");

            migrationBuilder.DropTable(
                name: "cpuclosedloopcooler");

            migrationBuilder.DropTable(
                name: "cpucooler_cpusocket_support");

            migrationBuilder.DropTable(
                name: "cpucooler_fan");

            migrationBuilder.DropTable(
                name: "cpuheatsink");

            migrationBuilder.DropTable(
                name: "gpu_displayconnector");

            migrationBuilder.DropTable(
                name: "motherboard_displayconnector");

            migrationBuilder.DropTable(
                name: "motherboard_ethernetport");

            migrationBuilder.DropTable(
                name: "motherboard_fanheader");

            migrationBuilder.DropTable(
                name: "motherboard_nvmeconnector");

            migrationBuilder.DropTable(
                name: "motherboard_pcieconnector");

            migrationBuilder.DropTable(
                name: "motherboard_ramsocket");

            migrationBuilder.DropTable(
                name: "motherboard_ramspeed");

            migrationBuilder.DropTable(
                name: "motherboard_sataconnector");

            migrationBuilder.DropTable(
                name: "motherboard_usbport");

            migrationBuilder.DropTable(
                name: "nvmessd");

            migrationBuilder.DropTable(
                name: "powersupply");

            migrationBuilder.DropTable(
                name: "radiator");

            migrationBuilder.DropTable(
                name: "ram");

            migrationBuilder.DropTable(
                name: "satahdd");

            migrationBuilder.DropTable(
                name: "satassd");

            migrationBuilder.DropTable(
                name: "fan");

            migrationBuilder.DropTable(
                name: "cpucooler");

            migrationBuilder.DropTable(
                name: "gpu");

            migrationBuilder.DropTable(
                name: "motherboard");

            migrationBuilder.DropTable(
                name: "storage");

            migrationBuilder.DropIndex(
                name: "ethernetport_chipset_unique",
                table: "ethernetport");

            migrationBuilder.RenameIndex(
                name: "audioport_pincount_connectorsize_unique",
                table: "audioport",
                newName: "IX_audioport_pincount_connectorsize");

            migrationBuilder.AlterColumn<int>(
                name: "fanvoltage",
                table: "fanvoltage",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "chassis_motherboardformfactorsupport_motherboardformfactoruuis_fkey",
                table: "chassis_motherboardformfactorsupport",
                column: "motherboardformfactoruuid",
                principalTable: "motherboardformfactor",
                principalColumn: "uuid");
        }
    }
}
