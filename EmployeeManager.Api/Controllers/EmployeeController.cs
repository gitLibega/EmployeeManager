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

        [HttpGet($"{nameof(GetAll)}")]
        public async Task<IEnumerable<EmployeeTableViewDto>> GetAll( [FromRoute] EmployeeGetAllQuery query)
        {
            return await _employeeService.GetAllEmployeesAsync(query);
        }

        [HttpGet($"{nameof(GetById)}/{{Id}}")]
        public async Task<EmployeeCardViewDto> GetById([FromRoute] EmployeeGetByIdQuery query)
        {
            return await _employeeService.GetEmployeeByIdAsync(query);
        }

        [HttpPost(nameof(Add))]
        public async Task Add([FromBody] EmployeeAddCommand command)
        {
            await _employeeService.AddEmployeeAsync(command);
        }

        [HttpPut(nameof(Update))]
        public async Task Update([FromBody] EmployeeUpdateCommand command)
        {
            await _employeeService.UpdateEmployeeAsync(command);
        }

        [HttpDelete($"{nameof(Delete)}/{{Id}}")]
        public async Task Delete([FromRoute] EmployeeDeleteCommand command)
        {
            await _employeeService.DeleteEmployeeAsync(command);
        }
    }
}
