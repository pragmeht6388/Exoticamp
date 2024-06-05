using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PRoertiesOfEventAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: new Guid("ed0cc6b6-11f4-4512-a441-625941917502"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Messages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Highlights",
                table: "Events",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventRules",
                table: "Events",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CampsiteId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampsiteId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Highlights",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EventRules",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[,]
                {
                    { new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"), "1", "en", "{PropertyName} is required.", "Error" },
                    { new Guid("ed0cc6b6-11f4-4512-a441-625941917502"), "2", "en", "{PropertyName} must not exceed {MaxLength} characters.", "Error" },
                    { new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"), "3", "en", "An event with the same name and date already exists.", "Error" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9934), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9913), 85, new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c") },
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9862), 400, new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b") },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9891), 135, new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340") },
                    { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 950, DateTimeKind.Utc), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9955), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 6, 3, 10, 35, 37, 949, DateTimeKind.Utc).AddTicks(9979), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") }
                });
        }
    }
}
