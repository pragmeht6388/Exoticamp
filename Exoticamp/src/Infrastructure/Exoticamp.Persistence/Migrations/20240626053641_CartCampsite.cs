using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CartCampsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartCamps",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    NoOfAdults = table.Column<int>(type: "int", nullable: true),
                    NoOfChildrens = table.Column<int>(type: "int", nullable: true),
                    NoOfTents = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampsiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlampingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfGlamps = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    GuestDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartCamps", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_cartCamps_CampsiteDetails_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartCamps_GuestDetails_GuestDetailsId",
                        column: x => x.GuestDetailsId,
                        principalTable: "GuestDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cartCamps_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartCamps_CampsiteId",
                table: "cartCamps",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_cartCamps_GuestDetailsId",
                table: "cartCamps",
                column: "GuestDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_cartCamps_LocationId",
                table: "cartCamps",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartCamps");
        }
    }
}
