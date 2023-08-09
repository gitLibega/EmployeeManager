using EmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task AddEmployeeAsync(Employee employee);

        public Task UpdateEmployeeAsync(Employee employee);

        public Task DeleteEmployeeAsync(int employeeId);

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        public Task<Employee> GetEmployeeByIdAsync(int employeeId);

    }
}
