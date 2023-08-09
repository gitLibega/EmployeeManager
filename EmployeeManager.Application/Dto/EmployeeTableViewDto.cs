using EmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Application.Dto
{
    public class EmployeeTableViewDto
    {
        public EmployeeTableViewDto() { }

        public EmployeeTableViewDto(Employee entity) {
            Id = entity.Id;
            FullName = $"{entity.LastName} {entity.FirstName} {entity.Patronymic}";
            DateOfBirth = entity.DateOfBirth;
            DateOfEmployment = entity.DateOfEmployment;
            Salary = entity.Salary;
            Department = entity.Department;
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
}
