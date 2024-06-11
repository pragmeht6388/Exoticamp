using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_CampsiteDetails_LocationId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Locations_LocationId",
                table: "CampsiteDetails");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CampsiteDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "CampsiteDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
