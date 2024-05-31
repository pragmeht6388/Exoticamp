using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class removetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b19ae32-5a4d-4539-b7b5-67121998a88c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aff2ae3-3de6-4e3c-a3ed-d9bab3d47844");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae94390-20d8-4923-a6dd-20bb7845a6a1");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a333eba-64fb-4cbf-bc66-6cd472962814", null, "SuperAdmin", "SUPERADMIN" },
                    { "e458e53f-1009-4511-ae54-6b10c2da1a55", null, "User", "USER" },
                    { "f6f055ba-b903-4838-9be3-9a9ddfe0ed4d", null, "Vendor", "VENDOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a333eba-64fb-4cbf-bc66-6cd472962814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e458e53f-1009-4511-ae54-6b10c2da1a55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6f055ba-b903-4838-9be3-9a9ddfe0ed4d");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b19ae32-5a4d-4539-b7b5-67121998a88c", null, "Vendor", "VENDOR" },
                    { "4aff2ae3-3de6-4e3c-a3ed-d9bab3d47844", null, "SuperAdmin", "SUPERADMIN" },
                    { "fae94390-20d8-4923-a6dd-20bb7845a6a1", null, "User", "USER" }
                });
        }
    }
}
