using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTentAvaialbilty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Glamping_CampsiteDetails_CampsiteId",
                table: "Glamping");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageAvailabilities_Glamping_GlampingId",
                table: "ManageAvailabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Glamping",
                table: "Glamping");

            migrationBuilder.DropIndex(
                name: "IX_Glamping_CampsiteId",
                table: "Glamping");

            migrationBuilder.DropColumn(
                name: "CampsiteId",
                table: "Glamping");

            migrationBuilder.RenameTable(
                name: "Glamping",
                newName: "Glamps");

            migrationBuilder.AddColumn<Guid>(
                name: "GlampingId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Glamps",
                table: "Glamps",
                column: "GlampingId");

            migrationBuilder.CreateTable(
                name: "BlockedDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlampingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfPersons = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TentAvailability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlampingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableTents = table.Column<int>(type: "int", nullable: false),
                    BookedTents = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TentAvailability", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_TentId",
                table: "CampsiteDetails",
                column: "TentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Tents_TentId",
                table: "CampsiteDetails",
                column: "TentId",
                principalTable: "Tents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAvailabilities_Glamps_GlampingId",
                table: "ManageAvailabilities",
                column: "GlampingId",
                principalTable: "Glamps",
                principalColumn: "GlampingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Tents_TentId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageAvailabilities_Glamps_GlampingId",
                table: "ManageAvailabilities");

            migrationBuilder.DropTable(
                name: "BlockedDates");

            migrationBuilder.DropTable(
                name: "TentAvailability");

            migrationBuilder.DropIndex(
                name: "IX_CampsiteDetails_TentId",
                table: "CampsiteDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Glamps",
                table: "Glamps");

            migrationBuilder.DropColumn(
                name: "GlampingId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Glamps",
                newName: "Glamping");

            migrationBuilder.AddColumn<Guid>(
                name: "CampsiteId",
                table: "Glamping",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Glamping",
                table: "Glamping",
                column: "GlampingId");

            migrationBuilder.CreateIndex(
                name: "IX_Glamping_CampsiteId",
                table: "Glamping",
                column: "CampsiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Glamping_CampsiteDetails_CampsiteId",
                table: "Glamping",
                column: "CampsiteId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAvailabilities_Glamping_GlampingId",
                table: "ManageAvailabilities",
                column: "GlampingId",
                principalTable: "Glamping",
                principalColumn: "GlampingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
