using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieTracker.Data.Migrations
{
    public partial class CC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0854a12-a63e-4ccb-878c-ab3fbcf4b7aa");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(nullable: true),
                    CalorieAmmount = table.Column<int>(nullable: false),
                    ProteinAmount = table.Column<int>(nullable: false),
                    FatAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
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
                    StartingCalories = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
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
                name: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId1 = table.Column<int>(nullable: true),
                    TimeLogged = table.Column<DateTime>(nullable: false),
                    HealthEnthusiastId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_Foods_FoodId1",
                        column: x => x.FoodId1,
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

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalWeight = table.Column<int>(nullable: false),
                    GoalCalories = table.Column<int>(nullable: false),
                    WeeklyWeight = table.Column<int>(nullable: false),
                    HealthEnthusiastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Health_Enthusiasts_HealthEnthusiastId",
                        column: x => x.HealthEnthusiastId,
                        principalTable: "Health_Enthusiasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c90d6816-6c47-4c74-949f-e1ac5b1f2bb0", "30b32a4f-bf66-49dc-a6e3-735420ff2684", "Health Enthusiast", "Health Enthusiast" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_FoodId",
                table: "FoodDiaries",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_FoodId1",
                table: "FoodDiaries",
                column: "FoodId1");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_HealthEnthusiastId",
                table: "FoodDiaries",
                column: "HealthEnthusiastId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Health_Enthusiasts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c90d6816-6c47-4c74-949f-e1ac5b1f2bb0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0854a12-a63e-4ccb-878c-ab3fbcf4b7aa", "64e7ddbe-2580-4cd7-99f2-959ce1b3f1e5", "Health Enthusiast", "Health Enthusiast" });
        }
    }
}
