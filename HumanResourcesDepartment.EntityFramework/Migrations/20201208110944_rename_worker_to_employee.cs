using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesDepartment.EntityFramework.Migrations
{
    public partial class rename_worker_to_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Workers_WorkerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousWorkPlaces_Workers_WorkerId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_PreviousWorkPlaces_WorkerId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Positions_WorkerId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PreviousWorkPlaces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Tin = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    ContactEmail = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviousWorkPlaces_EmployeeId",
                table: "PreviousWorkPlaces",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_EmployeeId",
                table: "Positions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Employees_EmployeeId",
                table: "Positions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousWorkPlaces_Employees_EmployeeId",
                table: "PreviousWorkPlaces",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Employees_EmployeeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousWorkPlaces_Employees_EmployeeId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_PreviousWorkPlaces_EmployeeId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Positions_EmployeeId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PreviousWorkPlaces");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "PreviousWorkPlaces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Tin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviousWorkPlaces_WorkerId",
                table: "PreviousWorkPlaces",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkerId",
                table: "Positions",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AddressId",
                table: "Workers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Workers_WorkerId",
                table: "Positions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousWorkPlaces_Workers_WorkerId",
                table: "PreviousWorkPlaces",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
