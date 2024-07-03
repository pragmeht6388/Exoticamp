using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "cartCamps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cartCamps_EventId",
                table: "cartCamps",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartCamps_Events_EventId",
                table: "cartCamps",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartCamps_Events_EventId",
                table: "cartCamps");

            migrationBuilder.DropIndex(
                name: "IX_cartCamps_EventId",
                table: "cartCamps");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "cartCamps");
        }
    }
}
