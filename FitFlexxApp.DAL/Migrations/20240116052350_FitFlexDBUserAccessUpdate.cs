using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexxApp.DAL.Migrations
{
    public partial class FitFlexDBUserAccessUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Plans",
                newName: "UserAccessPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                newName: "IX_Plans_UserAccessPlanId");

            migrationBuilder.CreateTable(
                name: "UserAccessPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessFee = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccessPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessPlans_UserId",
                table: "UserAccessPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserAccessPlans_UserAccessPlanId",
                table: "Plans",
                column: "UserAccessPlanId",
                principalTable: "UserAccessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserAccessPlans_UserAccessPlanId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "UserAccessPlans");

            migrationBuilder.RenameColumn(
                name: "UserAccessPlanId",
                table: "Plans",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_UserAccessPlanId",
                table: "Plans",
                newName: "IX_Plans_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
