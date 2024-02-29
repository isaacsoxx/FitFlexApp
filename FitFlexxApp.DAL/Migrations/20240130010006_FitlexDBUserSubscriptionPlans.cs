using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexApp.DAL.Migrations
{
    public partial class FitlexDBUserSubscriptionPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserAccessPlans_UserAccessPlanId",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "UserAccessPlanId",
                table: "Plans",
                newName: "UserSubscriptionPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_UserAccessPlanId",
                table: "Plans",
                newName: "IX_Plans_UserSubscriptionPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserAccessPlans_UserSubscriptionPlanId",
                table: "Plans",
                column: "UserSubscriptionPlanId",
                principalTable: "UserAccessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserAccessPlans_UserSubscriptionPlanId",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "UserSubscriptionPlanId",
                table: "Plans",
                newName: "UserAccessPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_UserSubscriptionPlanId",
                table: "Plans",
                newName: "IX_Plans_UserAccessPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserAccessPlans_UserAccessPlanId",
                table: "Plans",
                column: "UserAccessPlanId",
                principalTable: "UserAccessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
