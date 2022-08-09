using System;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet]
		//https://localhost:44339/api/employees
		public async Task<ActionResult> GetEmployeesAsync()
		{
			try
			{
				return Ok(await _employeeRepository.GetEmployeesAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

		//https://localhost:44339/api/employees
		[HttpGet("{employeeId:int}")]
		public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int employeeId)
		{
			try
			{
				var result = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

				if (result == null)
				{
					return NotFound();
				}

				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}
	}
}