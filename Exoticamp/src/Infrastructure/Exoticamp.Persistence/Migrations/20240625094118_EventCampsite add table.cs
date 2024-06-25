using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EventCampsiteaddtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GlampingId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "NoOfGlamps",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventCampsites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCampsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCampsites_CampsiteDetails_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCampsites_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCampsites_CampsiteId",
                table: "EventCampsites",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCampsites_EventId",
                table: "EventCampsites",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCampsites");

            migrationBuilder.DropColumn(
                name: "NoOfGlamps",
                table: "Bookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "GlampingId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
