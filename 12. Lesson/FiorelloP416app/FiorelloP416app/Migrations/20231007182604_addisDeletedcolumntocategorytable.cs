using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloP416app.Migrations
{
    public partial class addisDeletedcolumntocategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Categories");
        }
    }
}
