using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class campsitedetailsandactivitiesmappingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CampsiteDetails_Activities_ActivitiesId",
            //    table: "CampsiteDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Events_Categories_CategoryId",
            //    table: "Events");

            //migrationBuilder.DropIndex(
            //    name: "IX_Events_CategoryId",
            //    table: "Events");

            //migrationBuilder.DropIndex(
            //    name: "IX_CampsiteDetails_ActivitiesId",
            //    table: "CampsiteDetails");

            //migrationBuilder.DropColumn(
            //    name: "CategoryId",
            //    table: "Events");

            //migrationBuilder.DropColumn(
            //    name: "ActivitiesId",
            //    table: "CampsiteDetails");

            migrationBuilder.CreateTable(
                name: "CampsiteActivities",
                columns: table => new
                {
                    CampsiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteActivities", x => new { x.CampsiteId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_CampsiteActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampsiteActivities_CampsiteDetails_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteActivities_ActivityId",
                table: "CampsiteActivities",
                column: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampsiteActivities");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivitiesId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
