using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexxApp.DAL.Migrations
{
    public partial class FitFlexDBPlanTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Plans",
                newName: "PlanTypeId");

            migrationBuilder.CreateTable(
                name: "PlanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanTypeId",
                table: "Plans",
                column: "PlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanType_PlanTypeId",
                table: "Plans",
                column: "PlanTypeId",
                principalTable: "PlanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanType_PlanTypeId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "PlanTypes");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanTypeId",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "PlanTypeId",
                table: "Plans",
                newName: "Type");
        }
    }
}
