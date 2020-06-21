using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SensorDatabase.Migrations
{
    public partial class CreateLocalSensorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sensorTypes",
                columns: table => new
                {
                    typeID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    typeName = table.Column<string>(nullable: true),
                    Units = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensorTypes", x => x.typeID);
                });

            migrationBuilder.CreateTable(
                name: "softwares",
                columns: table => new
                {
                    softwareID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SWName = table.Column<string>(nullable: true),
                    Revision = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_softwares", x => x.softwareID);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    deviceID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    typeID = table.Column<int>(nullable: true),
                    deviceName = table.Column<string>(nullable: true),
                    softwareID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.deviceID);
                    table.ForeignKey(
                        name: "FK_devices_softwares_softwareID",
                        column: x => x.softwareID,
                        principalTable: "softwares",
                        principalColumn: "softwareID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_devices_sensorTypes_typeID",
                        column: x => x.typeID,
                        principalTable: "sensorTypes",
                        principalColumn: "typeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    dataID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    deviceID = table.Column<int>(nullable: true),
                    ReadTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.dataID);
                    table.ForeignKey(
                        name: "FK_DataPoints_devices_deviceID",
                        column: x => x.deviceID,
                        principalTable: "devices",
                        principalColumn: "deviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_deviceID",
                table: "DataPoints",
                column: "deviceID");

            migrationBuilder.CreateIndex(
                name: "IX_devices_softwareID",
                table: "devices",
                column: "softwareID");

            migrationBuilder.CreateIndex(
                name: "IX_devices_typeID",
                table: "devices",
                column: "typeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPoints");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "softwares");

            migrationBuilder.DropTable(
                name: "sensorTypes");
        }
    }
}
