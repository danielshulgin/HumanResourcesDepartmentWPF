using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesDepartment.EntityFramework.Migrations
{
    public partial class update_position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Positions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Positions");
        }
    }
}
