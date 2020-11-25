using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesDepartment.EntityFramework.Migrations
{
    public partial class add_name_for_profession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Professions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Professions");
        }
    }
}
