using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.IGenericRepo;
using UserManagement.Application.IServices;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.GenericRepo;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Services;

namespace UserManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // Register DepartmentRepository implementation
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            services.AddScoped<IAppUserService, AppUserService>();

            // Register GenericRepository implementation
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}