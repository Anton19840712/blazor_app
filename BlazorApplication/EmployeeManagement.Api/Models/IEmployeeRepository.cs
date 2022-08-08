using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetEmployeesAsync();
		Task<Employee> GetEmployeeAsync(int employeeId);
		Task<Employee> AddEmployeeAsync(Employee employee);
		Task<Employee> UpdateEmployeeAsync(Employee employee);
		void DeleteEmployeeAsync(int employeeId);
	}
}
