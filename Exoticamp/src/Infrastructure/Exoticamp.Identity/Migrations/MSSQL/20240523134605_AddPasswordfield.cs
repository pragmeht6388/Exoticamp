using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "TermsandCondition",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "TermsandCondition",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
    }
}
