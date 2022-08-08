using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext _appDbContext;

		public EmployeeRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			return await _appDbContext.Employees.ToListAsync();
		}

		public async Task<Employee> GetEmployeeAsync(int employeeId)
		{
			return await _appDbContext.Employees
				.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
		}

		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			var result = await _appDbContext.Employees.AddAsync(employee);
			await _appDbContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee employee)
		{
			var result = await _appDbContext.Employees
				.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

			if (result != null)
			{
				result.FirstName = employee.FirstName;
				result.LastName = employee.LastName;
				result.Email = employee.Email;
				result.DateOfBirth = employee.DateOfBirth;
				result.Gender = employee.Gender;
				result.DepartmentId = employee.DepartmentId;
				result.PhotoPath = employee.PhotoPath;

				await _appDbContext.SaveChangesAsync();

				return result;
			}

			return null;
		}

		public async void DeleteEmployeeAsync(int employeeId)
		{
			var result = await _appDbContext.Employees
				.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
			if (result != null)
			{
				_appDbContext.Employees.Remove(result);
				await _appDbContext.SaveChangesAsync();
			}
		}
	}
}