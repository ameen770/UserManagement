using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.IGenericRepo;
using UserManagement.Application.Interfaces;

namespace UserManagement.Application
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configuration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register DepartmentRepository implementation
            services.AddTransient<IDepartmentRepository>();

            // Register GenericRepository implementation
            services.AddTransient(typeof(IGenericRepository<>));
            return services;
        }
    }
}
