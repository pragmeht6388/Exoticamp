using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exoticamp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    BannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Locations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Campsites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Campsites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ChatbotResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatbotResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "UserQueries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQueries", x => x.Id);
                });

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
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_CampsiteDetails_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampsiteDetails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventRules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Musicals" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Concerts" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Plays" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Conferences" }
                });

            migrationBuilder.InsertData(
                table: "ChatbotResponses",
                columns: new[] { "Id", "Keyword", "ParentId", "Response" },
                values: new object[,]
                {
                    { 1, "Technical Issue", 0, null },
                    { 2, "Account Issue", 1, null },
                    { 3, "Cannot login", 1, "Please reset your password." },
                    { 4, "Update email", 2, "You can update your email in the account settings." },
                    { 5, "Forgot password", 2, "You can reset your password using the Forgot Password link." }
                });

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
                    { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(9029), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(8973), 85, new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c") },
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(8926), 400, new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b") },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(8953), 135, new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340") },
                    { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(9089), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(9050), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 5, 31, 7, 52, 24, 847, DateTimeKind.Utc).AddTicks(9071), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") }
                });

            migrationBuilder.InsertData(
                table: "UserQueries",
                columns: new[] { "Id", "Email", "IsDeleted", "Query", "Response" },
                values: new object[] { new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"), "s@gmail.com", false, "Is there any pickup service available for pune?", null });

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_ActivitiesId",
                table: "CampsiteDetails",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CampsiteDetails_CategoryId",
                table: "CampsiteDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "CampsiteDetails");

            migrationBuilder.DropTable(
                name: "Campsites");

            migrationBuilder.DropTable(
                name: "ChatbotResponses");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserQueries");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
