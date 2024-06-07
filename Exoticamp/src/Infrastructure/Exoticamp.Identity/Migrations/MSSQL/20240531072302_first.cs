using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
