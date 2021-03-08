using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InitialCalorieIntakeLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialCalorieIntakeLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Health_Enthusiasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    StartingWeight = table.Column<int>(nullable: false),
                    GoalWeight = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    InitialCalorieIntake = table.Column<int>(nullable: true),
                    GoalCalories = table.Column<int>(nullable: true),
                    WeeklyWeightLoss = table.Column<double>(nullable: true),
                    Activity = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Health_Enthusiasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Health_Enthusiasts_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalWeight = table.Column<int>(nullable: true),
                    GoalCalories = table.Column<int>(nullable: true),
                    WeeklyWeightLoss = table.Column<double>(nullable: true),
                    Activity = table.Column<int>(nullable: true),
                    HealthEnthusiastId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Health_Enthusiasts_HealthEnthusiastId",
                        column: x => x.HealthEnthusiastId,
                        principalTable: "Health_Enthusiasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSubscribed = table.Column<bool>(nullable: false),
                    HealthEnthusiastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsLetters_Health_Enthusiasts_HealthEnthusiastId",
                        column: x => x.HealthEnthusiastId,
                        principalTable: "Health_Enthusiasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(nullable: true),
                    CalorieAmmount = table.Column<int>(nullable: false),
                    ProteinAmount = table.Column<int>(nullable: false),
                    FatAmount = table.Column<int>(nullable: false),
                    ServingSize = table.Column<int>(nullable: false),
                    FoodDiaryId = table.Column<int>(nullable: true),
                    FoodDiaryId1 = table.Column<int>(nullable: true),
                    FoodDiaryId2 = table.Column<int>(nullable: true),
                    FoodDiaryId3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyCaloriesAccumulated = table.Column<int>(nullable: false),
                    FoodItemId = table.Column<int>(nullable: true),
                    HealthEnthusiastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_Foods_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_Health_Enthusiasts_HealthEnthusiastId",
                        column: x => x.HealthEnthusiastId,
                        principalTable: "Health_Enthusiasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56015b20-a95d-4076-8f30-dd0c18f3c69c", "64be4aba-b8af-4960-ad7a-cf7054e75341", "Health_Enthusiast", "HEALTH_ENTHUSIAST" });

            migrationBuilder.InsertData(
                table: "InitialCalorieIntakeLists",
                columns: new[] { "Id", "Calories", "Name" },
                values: new object[,]
                {
                    { 1, 72, "Eggs" },
                    { 2, 598, "Chocolate" },
                    { 3, 20, "Mixed Baby Lettuce" },
                    { 4, 400, "Macaroni And Cheese" },
                    { 5, 57, "Mayonnaise" },
                    { 6, 836, "Fast Food" },
                    { 7, 297, "Arroz Rojo (Mexican Rice)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_FoodItemId",
                table: "FoodDiaries",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_HealthEnthusiastId",
                table: "FoodDiaries",
                column: "HealthEnthusiastId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId",
                table: "Foods",
                column: "FoodDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId1",
                table: "Foods",
                column: "FoodDiaryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId2",
                table: "Foods",
                column: "FoodDiaryId2");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId3",
                table: "Foods",
                column: "FoodDiaryId3");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_HealthEnthusiastId",
                table: "Goals",
                column: "HealthEnthusiastId");

            migrationBuilder.CreateIndex(
                name: "IX_Health_Enthusiasts_IdentityUserId",
                table: "Health_Enthusiasts",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetters_HealthEnthusiastId",
                table: "NewsLetters",
                column: "HealthEnthusiastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId",
                table: "Foods",
                column: "FoodDiaryId",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId1",
                table: "Foods",
                column: "FoodDiaryId1",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId2",
                table: "Foods",
                column: "FoodDiaryId2",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId3",
                table: "Foods",
                column: "FoodDiaryId3",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Health_Enthusiasts_AspNetUsers_IdentityUserId",
                table: "Health_Enthusiasts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodDiaries_Foods_FoodItemId",
                table: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "InitialCalorieIntakeLists");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "Health_Enthusiasts");
        }
    }
}
