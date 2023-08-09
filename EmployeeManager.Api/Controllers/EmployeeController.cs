using EmployeeManager.Application.Commands.EmployeeCommands;
using EmployeeManager.Application.Dto;
using EmployeeManager.Application.Queries.EmployeeQueries;
using EmployeeManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet(Name = nameof(GetAll))]
        public async Task<IEnumerable<EmployeeTableViewDto>> GetAll( [FromHeader] EmployeeGetAllQuery query)
        {
            return await _employeeService.GetAllEmployeesAsync(query);
        }

        [HttpGet(Name = nameof(GetById))]
        public async Task<EmployeeCardViewDto> GetById([FromHeader] EmployeeGetByIdQuery query)
        {
            return await _employeeService.GetEmployeeByIdAsync(query);
        }

        [HttpPost(Name = nameof(Add))]
        public async Task Add([FromBody] EmployeeAddCommand command)
        {
            await _employeeService.AddEmployeeAsync(command);
        }

        [HttpPut(Name = nameof(Update))]
        public async Task Update([FromBody] EmployeeUpdateCommand command)
        {
            await _employeeService.UpdateEmployeeAsync(command);
        }

        [HttpDelete(Name = nameof(Delete))]
        public async Task Delete([FromBody] EmployeeDeleteCommand command)
        {
           await _employeeService.DeleteEmployeeAsync(command);
        }
    }
}
