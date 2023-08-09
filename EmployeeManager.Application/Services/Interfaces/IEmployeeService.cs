using EmployeeManager.Application.Commands.EmployeeCommands;
using EmployeeManager.Application.Dto;
using EmployeeManager.Application.Queries.EmployeeQueries;
using EmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Application.Services.Interfaces
{
     public interface IEmployeeService
    {
        public Task AddEmployeeAsync(EmployeeAddCommand command);

        public Task UpdateEmployeeAsync(EmployeeUpdateCommand command);

        public Task DeleteEmployeeAsync(EmployeeDeleteCommand command);

        public Task<IEnumerable<EmployeeTableViewDto>> GetAllEmployeesAsync(EmployeeGetAllQuery query);

        public Task<EmployeeCardViewDto> GetEmployeeByIdAsync(EmployeeGetByIdQuery query);
    }
}
