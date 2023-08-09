using EmployeeManager.Application.Services.Implementations;
using EmployeeManager.Application.Services.Interfaces;
using EmployeeManager.Infrastructure.Repositories;
using EmployeeManager.Infrastructure.Repositories.Implementations;
using EmployeeManager.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Api.IoC
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Services
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
