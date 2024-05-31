using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class campsite2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesCampsiteDetails");

            migrationBuilder.DropTable(
                name: "CampsiteDetailsCategory");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 56, 8, 211, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_CategoryId",
                table: "CampsiteDetails",
                column: "CategoryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Activities_ActivitiesId",
                table: "CampsiteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CampsiteDetails_Categories_CategoryId",
                table: "CampsiteDetails");

            migrationBuilder.DropIndex(
                name: "IX_CampsiteDetails_ActivitiesId",
                table: "CampsiteDetails");

            migrationBuilder.DropIndex(
                name: "IX_CampsiteDetails_CategoryId",
                table: "CampsiteDetails");

            migrationBuilder.CreateTable(
                name: "ActivitiesCampsiteDetails",
                columns: table => new
                {
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampsiteDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesCampsiteDetails", x => new { x.ActivitiesId, x.CampsiteDetailsId });
                    table.ForeignKey(
                        name: "FK_ActivitiesCampsiteDetails_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesCampsiteDetails_CampsiteDetails_CampsiteDetailsId",
                        column: x => x.CampsiteDetailsId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampsiteDetailsCategory",
                columns: table => new
                {
                    CampsiteDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteDetailsCategory", x => new { x.CampsiteDetailsId, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_CampsiteDetailsCategory_CampsiteDetails_CampsiteDetailsId",
                        column: x => x.CampsiteDetailsId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampsiteDetailsCategory_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 30, 9, 44, 12, 808, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesCampsiteDetails_CampsiteDetailsId",
                table: "ActivitiesCampsiteDetails",
                column: "CampsiteDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetailsCategory_CategoriesCategoryId",
                table: "CampsiteDetailsCategory",
                column: "CategoriesCategoryId");
        }
    }
}
