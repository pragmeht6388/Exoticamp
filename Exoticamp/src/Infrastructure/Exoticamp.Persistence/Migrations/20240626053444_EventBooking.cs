using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EventBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GlampingId",
                table: "TentAvailability",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "EventBooking",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    NoOfAdults = table.Column<int>(type: "int", nullable: true),
                    NoOfChildrens = table.Column<int>(type: "int", nullable: true),
                    NoOfTents = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlampingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NoOfGlamps = table.Column<int>(type: "int", nullable: true),
                    GuestDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsPaymentDone = table.Column<bool>(type: "bit", nullable: true),
                    IsPurged = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBooking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_EventBooking_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventBooking_GuestDetails_GuestDetailsId",
                        column: x => x.GuestDetailsId,
                        principalTable: "GuestDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventBooking_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventBookingCart",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    NoOfAdults = table.Column<int>(type: "int", nullable: true),
                    NoOfChildrens = table.Column<int>(type: "int", nullable: true),
                    NoOfTents = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlampingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NoOfGlamps = table.Column<int>(type: "int", nullable: true),
                    GuestDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBookingCart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_EventBookingCart_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_EventBookingCart_GuestDetails_GuestDetailsId",
                        column: x => x.GuestDetailsId,
                        principalTable: "GuestDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventBookingCart_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBooking_EventId",
                table: "EventBooking",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBooking_GuestDetailsId",
                table: "EventBooking",
                column: "GuestDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBooking_LocationId",
                table: "EventBooking",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBookingCart_EventId",
                table: "EventBookingCart",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBookingCart_GuestDetailsId",
                table: "EventBookingCart",
                column: "GuestDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBookingCart_LocationId",
                table: "EventBookingCart",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventBooking");

            migrationBuilder.DropTable(
                name: "EventBookingCart");

            migrationBuilder.AlterColumn<Guid>(
                name: "GlampingId",
                table: "TentAvailability",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
