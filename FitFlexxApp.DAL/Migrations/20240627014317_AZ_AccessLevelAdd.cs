using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlexApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AZ_AccessLevelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessLevelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingPlans",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccessLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccessLevelId",
                table: "Users",
                column: "AccessLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccessLevel_AccessLevelId",
                table: "Users",
                column: "AccessLevelId",
                principalTable: "AccessLevel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccessLevel_AccessLevelId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccessLevelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccessLevelId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingPlans",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
