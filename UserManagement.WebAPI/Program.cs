using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Application;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection
builder.Services.AddCoreDependencies();
/*builder.Services.AddInfrastructureDependencies();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));*/
#endregion

//Connection To SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<UserManager<AppUser>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure;
using UserManagement.Application;
using UserManagement.Application.IGenericRepo;
using UserManagement.Application.Interfaces;
using UserManagement.Infrastructure.GenericRepo;
using UserManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
*//*builder.Services.AddControllers().AddOData(opt =>
opt.OrderBy().Expand().Select().Filter().Count());*//*

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependency Injection
builder.Services.AddInfrastructureDependencies();
builder.Services.AddCoreDependencies();
*//*builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));*//*
#endregion

///
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                //builder.WithOrigins("http://localhost:7155")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
});
///


//Connection To SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<UserManager<AppUser>>();

var app = builder.Build();

///
// app.UseCors("AllowSpecificOrigin");
///


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/
