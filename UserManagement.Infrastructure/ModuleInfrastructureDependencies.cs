using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.IGenericRepo;
using UserManagement.Application.Services;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.GenericRepo;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Services;

namespace UserManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // Register DepartmentRepository implementation
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();

            // Register GenericRepository implementation
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}