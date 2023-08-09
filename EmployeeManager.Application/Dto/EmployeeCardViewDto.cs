using EmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Application.Dto
{
    public  class EmployeeCardViewDto
    {
        public EmployeeCardViewDto(Employee employee) {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Patronymic = employee.Patronymic;
            DateOfBirth = employee.DateOfBirth;
            DateOfEmployment = employee.DateOfEmployment;
            Department = employee.Department;
            Salary = employee.Salary;
        }

        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

    }
}
