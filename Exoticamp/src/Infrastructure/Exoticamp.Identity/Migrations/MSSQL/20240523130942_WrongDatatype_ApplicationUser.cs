using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class WrongDatatype_ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc3e963-77e8-4f47-9808-8df68d641dec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b3d0368-103a-4540-9c15-5eb1fd3f1285");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aca1fee-af25-4940-908d-4304736c3339");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d41d0d7-81e9-455d-9c82-a0ac8035eab8", null, "SuperAdmin", "SUPERADMIN" },
                    { "61b08ea4-918b-4787-8ce1-449034bf2224", null, "Vendor", "VENDOR" },
                    { "90f077f0-7e88-46cf-839a-12477628b738", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d41d0d7-81e9-455d-9c82-a0ac8035eab8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b08ea4-918b-4787-8ce1-449034bf2224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90f077f0-7e88-46cf-839a-12477628b738");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fc3e963-77e8-4f47-9808-8df68d641dec", null, "User", "USER" },
                    { "5b3d0368-103a-4540-9c15-5eb1fd3f1285", null, "SuperAdmin", "SUPERADMIN" },
                    { "9aca1fee-af25-4940-908d-4304736c3339", null, "Vendor", "VENDOR" }
                });
        }
    }
}
