using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PRoertiesOfEventAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_CampsiteId",
                table: "Events",
                column: "CampsiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_CampsiteDetails_CampsiteId",
                table: "Events",
                column: "CampsiteId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_CampsiteDetails_CampsiteId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CampsiteId",
                table: "Events");
        }
    }
}
