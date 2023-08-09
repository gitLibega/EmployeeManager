using EmployeeManager.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Application.Commands.EmployeeCommands
{
    public class EmployeeAddCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
}
