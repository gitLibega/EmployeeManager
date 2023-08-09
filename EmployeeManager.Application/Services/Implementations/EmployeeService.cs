using EmployeeManager.Application.Commands.EmployeeCommands;
using EmployeeManager.Application.Dto;
using EmployeeManager.Application.Queries.EmployeeQueries;
using EmployeeManager.Application.Services.Interfaces;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Application.Services.Implementations
{
    public class EmployeeService: IEmployeeService
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository)) ;
        }

        public async Task AddEmployeeAsync(EmployeeAddCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var newEntity = new Employee()
            {
                DateOfBirth = command.DateOfBirth,
                DateOfEmployment = command.DateOfEmployment,
                Department = command.Department,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Patronymic = command.Patronymic,
                Salary = command.Salary 
            };

           await _employeeRepository.AddEmployeeAsync(newEntity);
            
        }

        public async Task DeleteEmployeeAsync(EmployeeDeleteCommand command)
        {
            if (command == null )  throw new ArgumentNullException(nameof(command));

            await _employeeRepository.DeleteEmployeeAsync(command.Id);
        }

        public async Task<IEnumerable<EmployeeTableViewDto>> GetAllEmployeesAsync(EmployeeGetAllQuery query)
        {
            var result = (await _employeeRepository.GetAllEmployeesAsync()).Select(x => new EmployeeTableViewDto(x));

            return result;
        }

        public async Task<EmployeeCardViewDto> GetEmployeeByIdAsync(EmployeeGetByIdQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var result = new EmployeeCardViewDto(await _employeeRepository.GetEmployeeByIdAsync(query.Id));

            return result;
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var updEntity = new Employee()
            {
                Id = command.Id,
                DateOfBirth = command.DateOfBirth,
                DateOfEmployment = command.DateOfEmployment,
                Department = command.Department,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Patronymic = command.Patronymic,
                Salary = command.Salary
            };

            await _employeeRepository.UpdateEmployeeAsync(updEntity);
        }
    }
}
