using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
	public class EmployeeListBase :ComponentBase
	{
		public IEnumerable<Employee> Employees { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await Task.Run(LoadEmployees);
		}

		private void LoadEmployees()
		{
			Thread.Sleep(3000);

			Employee e1 = new Employee
			{
				EmployeeId = 1,
				FirstName = "John",
				LastName = "Hastings",
				Email = "David@pragimtech.com",
				DateOfBirth = new DateTime(1980, 10, 5),
				Gender = Gender.Male,
				DepartmentId = 1,
				PhotoPath = "images/JohnHastings.png"
			};

			Employee e2 = new Employee
			{
				EmployeeId = 2,
				FirstName = "Sam",
				LastName = "Galloway",
				Email = "Sam@pragimtech.com",
				DateOfBirth = new DateTime(1981, 12, 22),
				Gender = Gender.Male,
				DepartmentId = 2,
				PhotoPath = "images/SamGalloway.png"
			};

			Employees = new List<Employee> { e1, e2 };
		}
	}
}