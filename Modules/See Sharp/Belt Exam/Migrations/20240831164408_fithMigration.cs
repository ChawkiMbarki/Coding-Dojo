using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Belt_Exam.Migrations
{
    public partial class fithMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Recipies");

            migrationBuilder.AddColumn<bool>(
                name: "Gluten",
                table: "Recipies",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vegitarian",
                table: "Recipies",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gluten",
                table: "Recipies");

            migrationBuilder.DropColumn(
                name: "Vegitarian",
                table: "Recipies");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Recipies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
