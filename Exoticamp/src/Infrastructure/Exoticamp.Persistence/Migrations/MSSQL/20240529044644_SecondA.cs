using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCleanProject1.Persistence.Migrations.MSSQL
{
    /// <inheritdoc />
    public partial class SecondA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampsiteDetailsId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampsiteDetailsId",
                table: "Activities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampsiteDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ratings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCampsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampsiteRules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestTimeToVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HowToGetHere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuickSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealPlans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itinerary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inclusions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceWithMap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyExoticamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseRules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovededDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletededBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteDetails", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "CampsiteDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "CampsiteDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                column: "CampsiteDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                column: "CampsiteDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 4, 46, 41, 729, DateTimeKind.Utc).AddTicks(8964));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CampsiteDetailsId",
                table: "Categories",
                column: "CampsiteDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CampsiteDetailsId",
                table: "Activities",
                column: "CampsiteDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_CampsiteDetails_CampsiteDetailsId",
                table: "Activities",
                column: "CampsiteDetailsId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CampsiteDetails_CampsiteDetailsId",
                table: "Categories",
                column: "CampsiteDetailsId",
                principalTable: "CampsiteDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_CampsiteDetails_CampsiteDetailsId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CampsiteDetails_CampsiteDetailsId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CampsiteDetails");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CampsiteDetailsId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CampsiteDetailsId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CampsiteDetailsId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CampsiteDetailsId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 911, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 912, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 912, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 28, 10, 23, 11, 912, DateTimeKind.Utc).AddTicks(164));
        }
    }
}
