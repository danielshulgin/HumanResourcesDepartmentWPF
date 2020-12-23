using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesDepartment.EntityFramework.Migrations
{
    public partial class update_employee_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessRights",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessRights",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");
        }
    }
}
