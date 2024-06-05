using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PRoertiesOfEventAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventLocationId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventActivitiesId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventLocationId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventActivitiesId",
                table: "Activities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EventLocationId",
                table: "Locations",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventActivitiesId",
                table: "Events",
                column: "EventActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventLocationId",
                table: "Events",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EventActivitiesId",
                table: "Activities",
                column: "EventActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_EventActivities_EventActivitiesId",
                table: "Activities",
                column: "EventActivitiesId",
                principalTable: "EventActivities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventActivities_EventActivitiesId",
                table: "Events",
                column: "EventActivitiesId",
                principalTable: "EventActivities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventLocations_EventLocationId",
                table: "Events",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_EventLocations_EventLocationId",
                table: "Locations",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_EventActivities_EventActivitiesId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventActivities_EventActivitiesId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventLocations_EventLocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_EventLocations_EventLocationId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "EventActivities");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_EventLocationId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventActivitiesId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventLocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EventActivitiesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EventActivitiesId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventActivitiesId",
                table: "Activities");
        }
    }
}
