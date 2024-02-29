using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexApp.DAL.Migrations
{
    public partial class FitlexDBUserSubscriptionPlansTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserAccessPlans_UserSubscriptionPlanId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessPlans_Users_UserId",
                table: "UserAccessPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccessPlans",
                table: "UserAccessPlans");

            migrationBuilder.RenameTable(
                name: "UserAccessPlans",
                newName: "UserSubscriptionPlans");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccessPlans_UserId",
                table: "UserSubscriptionPlans",
                newName: "IX_UserSubscriptionPlans_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubscriptionPlans",
                table: "UserSubscriptionPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserSubscriptionPlans_UserSubscriptionPlanId",
                table: "Plans",
                column: "UserSubscriptionPlanId",
                principalTable: "UserSubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptionPlans_Users_UserId",
                table: "UserSubscriptionPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserSubscriptionPlans_UserSubscriptionPlanId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptionPlans_Users_UserId",
                table: "UserSubscriptionPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubscriptionPlans",
                table: "UserSubscriptionPlans");

            migrationBuilder.RenameTable(
                name: "UserSubscriptionPlans",
                newName: "UserAccessPlans");

            migrationBuilder.RenameIndex(
                name: "IX_UserSubscriptionPlans_UserId",
                table: "UserAccessPlans",
                newName: "IX_UserAccessPlans_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccessPlans",
                table: "UserAccessPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserAccessPlans_UserSubscriptionPlanId",
                table: "Plans",
                column: "UserSubscriptionPlanId",
                principalTable: "UserAccessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessPlans_Users_UserId",
                table: "UserAccessPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
