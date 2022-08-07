using System;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//seeding
			modelBuilder.Entity<Department>().HasData(
				new Department {DepartmentId = 1, DepartmentName = "IT"},
				new Department {DepartmentId = 2, DepartmentName = "HR"},
				new Department {DepartmentId = 3, DepartmentName = "Payroll"}
			);

			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 1,
				FirstName = "John",
				LastName = "Hastings",
				Email = "john@pragimtech.com",
				DateOfBirth = new DateTime(1980, 10, 5),
				Gender = Gender.Male,
				DepartmentId = 1,
				PhotoPath = "images/JohnHastings.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 2,
				FirstName = "Ivan",
				LastName = "Hastings",
				Email = "ivan@pragimtech.com",
				DateOfBirth = new DateTime(1983, 10, 5),
				Gender = Gender.Male,
				DepartmentId = 1,
				PhotoPath = "images/IvanHastings.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 3,
				FirstName = "Polly",
				LastName = "Trump",
				Email = "polly@pragimtech.com",
				DateOfBirth = new DateTime(1987, 10, 5),
				Gender = Gender.Female,
				DepartmentId = 3,
				PhotoPath = "images/IvanHastings.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 4,
				FirstName = "Marry",
				LastName = "Roberts",
				Email = "marry@pragimtech.com",
				DateOfBirth = new DateTime(1987, 10, 5),
				Gender = Gender.Female,
				DepartmentId = 3,
				PhotoPath = "images/IvanHastings.png"
			});
		}
	}
}
