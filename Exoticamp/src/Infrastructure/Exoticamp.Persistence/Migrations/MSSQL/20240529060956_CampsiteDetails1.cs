using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCleanProject1.Persistence.Migrations.MSSQL
{
    /// <inheritdoc />
    public partial class CampsiteDetails1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_CampsiteDetails_CampsiteDetailsId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CampsiteDetails_CampsiteDetailsId",
                table: "Categories");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ActivitiesId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "CampsiteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ActivitiesCampsiteDetails",
                columns: table => new
                {
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivitiesId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesCampsiteDetails", x => new { x.ActivitiesId, x.ActivitiesId1 });
                    table.ForeignKey(
                        name: "FK_ActivitiesCampsiteDetails_Activities_ActivitiesId1",
                        column: x => x.ActivitiesId1,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesCampsiteDetails_CampsiteDetails_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "CampsiteDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampsiteDetailsCategory",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteDetailsCategory", x => new { x.CategoriesCategoryId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CampsiteDetailsCategory_CampsiteDetails_CategoryId",
                        column: x => x.CategoryId,
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
                value: new DateTime(2025, 3, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 6, 9, 55, 212, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesCampsiteDetails_ActivitiesId1",
                table: "ActivitiesCampsiteDetails",
                column: "ActivitiesId1");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetailsCategory_CategoryId",
                table: "CampsiteDetailsCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesCampsiteDetails");

            migrationBuilder.DropTable(
                name: "CampsiteDetailsCategory");

            migrationBuilder.DropColumn(
                name: "ActivitiesId",
                table: "CampsiteDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CampsiteDetails");

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
                value: new DateTime(2025, 3, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 28, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 29, 5, 53, 23, 754, DateTimeKind.Utc).AddTicks(5929));

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
    }
}
