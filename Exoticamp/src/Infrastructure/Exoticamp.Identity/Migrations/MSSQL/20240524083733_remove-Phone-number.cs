using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class removePhonenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d6747d2-7af4-47b1-853d-f93dc02cd469", null, "SuperAdmin", "SUPERADMIN" },
                    { "8bb884a0-a525-41c5-b382-e984df6fc587", null, "Vendor", "VENDOR" },
                    { "ece96ccc-1192-4f0d-af81-32c8666db888", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6747d2-7af4-47b1-853d-f93dc02cd469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bb884a0-a525-41c5-b382-e984df6fc587");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ece96ccc-1192-4f0d-af81-32c8666db888");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
