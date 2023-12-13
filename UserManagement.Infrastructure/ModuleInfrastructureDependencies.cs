using Microsoft.Extensions.DependencyInjection;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.GenericRepo;
using UserManagement.Application.IGenericRepo;
using UserManagement.Application.Interfaces;

namespace UserManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        /*public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) 
        {
            *//*services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));*//*

            // Register DepartmentRepository implementation
            services.AddTransient<DepartmentRepository>();

            // Register GenericRepository implementation
            services.AddTransient(typeof(GenericRepository<>));
            return services;
        }*/
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // Register DepartmentRepository implementation
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            // Register GenericRepository implementation
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
