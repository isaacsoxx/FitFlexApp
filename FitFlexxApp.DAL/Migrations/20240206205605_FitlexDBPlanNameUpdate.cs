using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexApp.DAL.Migrations
{
    public partial class FitlexDBPlanNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Plans",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plans",
                newName: "Description");
        }
    }
}
