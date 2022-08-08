using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EmployeeManagement.Api.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Departments",
				columns: table => new
				{
					DepartmentId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Departments", x => x.DepartmentId);
				});

			migrationBuilder.CreateTable(
				name: "Employees",
				columns: table => new
				{
					EmployeeId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
					Gender = table.Column<int>(type: "int", nullable: false),
					DepartmentId = table.Column<int>(type: "int", nullable: false),
					PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Employees", x => x.EmployeeId);
				});

			migrationBuilder.InsertData(
				table: "Departments",
				columns: new[] { "DepartmentId", "DepartmentName" },
				values: new object[,]
				{
					{ 1, "IT" },
					{ 2, "HR" },
					{ 3, "Payroll" }
				});

			migrationBuilder.InsertData(
				table: "Employees",
				columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
				values: new object[,]
				{
					{ 1, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john@pragimtech.com", "John", 0, "Hastings", "images/JohnHastings.png" },
					{ 2, new DateTime(1983, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ivan@pragimtech.com", "Ivan", 0, "Hastings", "images/IvanHastings.png" },
					{ 3, new DateTime(1987, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "polly@pragimtech.com", "Polly", 1, "Trump", "images/IvanHastings.png" },
					{ 4, new DateTime(1987, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "marry@pragimtech.com", "Marry", 1, "Roberts", "images/IvanHastings.png" }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Departments");

			migrationBuilder.DropTable(
				name: "Employees");
		}
	}
}
