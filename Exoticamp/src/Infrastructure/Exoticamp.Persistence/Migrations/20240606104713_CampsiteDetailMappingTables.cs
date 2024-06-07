using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CampsiteDetailMappingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Categories_CategoryId",
                table: "CampsiteDetails");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CampsiteDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivitiesId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "CampsiteDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampsiteActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampsiteActivities_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampsiteActivities_CampsiteDetails_CampsiteDetailsId",
                        column: x => x.CampsiteDetailsId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampsiteCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampsiteCategories_CampsiteDetails_CampsiteDetailsId",
                        column: x => x.CampsiteDetailsId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampsiteCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_LocationId",
                table: "CampsiteDetails",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteActivities_ActivitiesId",
                table: "CampsiteActivities",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteActivities_CampsiteDetailsId",
                table: "CampsiteActivities",
                column: "CampsiteDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteCategories_CampsiteDetailsId",
                table: "CampsiteCategories",
                column: "CampsiteDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteCategories_CategoryId",
                table: "CampsiteCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Categories_CategoryId",
                table: "CampsiteDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Locations_LocationId",
                table: "CampsiteDetails",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Categories_CategoryId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Locations_LocationId",
                table: "CampsiteDetails");

            migrationBuilder.DropTable(
                name: "CampsiteActivities");

            migrationBuilder.DropTable(
                name: "CampsiteCategories");

            migrationBuilder.DropIndex(
                name: "IX_CampsiteDetails_LocationId",
                table: "CampsiteDetails");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CampsiteDetails");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "CampsiteDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivitiesId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CampsiteDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampsiteDetails_Categories_CategoryId",
                table: "CampsiteDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
