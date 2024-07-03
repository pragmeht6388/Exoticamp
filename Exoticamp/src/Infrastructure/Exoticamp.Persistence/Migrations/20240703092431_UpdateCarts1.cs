using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarts1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartCamps_CampsiteDetails_CampsiteId",
                table: "cartCamps");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampsiteId",
                table: "cartCamps",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_cartCamps_CampsiteDetails_CampsiteId",
                table: "cartCamps",
                column: "CampsiteId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartCamps_CampsiteDetails_CampsiteId",
                table: "cartCamps");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampsiteId",
                table: "cartCamps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cartCamps_CampsiteDetails_CampsiteId",
                table: "cartCamps",
                column: "CampsiteId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
