using EmployeeManager.Domain.Entities;
using EmployeeManager.Infrastructure.Context;
using EmployeeManager.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagerContext _context;
        public EmployeeRepository(EmployeeManagerContext context) {
            _context = context;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if(employee == null) throw new ArgumentNullException(nameof(employeeId));

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee == null) throw new ArgumentNullException(nameof(employeeId));

            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var emplo = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (emplo == null) throw new ArgumentNullException(nameof(employee));

            emplo.FirstName = employee.FirstName;
            emplo.LastName = employee.LastName;
            emplo.Patronymic = employee.Patronymic;
            emplo.DateOfBirth = employee.DateOfBirth;
            emplo.Salary = employee.Salary;
            emplo.Department = employee.Department;
            emplo.DateOfEmployment = employee.DateOfEmployment;

            _context.Employees.Update(emplo);
            await _context.SaveChangesAsync();
        }
    }
}
