using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Core.Department.Data;
using WebApiCore.Core.Department.Data.Interfaces;
using WebApiCore.Core.Department.Service;
using WebApiCore.Core.Department.Service.Interfaces;
using WebApiCore.Core.Employee.Data;
using WebApiCore.Core.Employee.Data.Interfaces;
using WebApiCore.Core.User.Data;
using WebApiCore.Core.User.Data.Interfaces;




namespace WebApiCore.Core
{
    public static class CoreExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentReposiory, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
