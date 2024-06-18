using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCleanProject1.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedClassUserKYC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserKYC_UserID",
                table: "UserKYC");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_UserID",
                table: "BankDetails");

            migrationBuilder.CreateIndex(
                name: "IX_UserKYC_UserID",
                table: "UserKYC",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_UserID",
                table: "BankDetails",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserKYC_UserID",
                table: "UserKYC");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_UserID",
                table: "BankDetails");

            migrationBuilder.CreateIndex(
                name: "IX_UserKYC_UserID",
                table: "UserKYC",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_UserID",
                table: "BankDetails",
                column: "UserID");
        }
    }
}
