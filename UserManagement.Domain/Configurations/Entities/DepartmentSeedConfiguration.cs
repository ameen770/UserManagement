using UserManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserManagement.Domain.Configurations.Entities
{
    public class DepartmentSeedConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                 new Department
                 {
                     Id = 1,
                     Name = "Management_Department",
                     CreatedDate = DateTime.Now,
                     ModifiedDate = null
                 },
                 new Department
                 {
                     Id = 2,
                     Name = "Employees_Department",
                     CreatedDate = DateTime.Now,
                     ModifiedDate = null
                 },
                 new Department
                 {
                     Id = 3,
                     Name = "Users_Department",
                     CreatedDate = DateTime.Now,
                     ModifiedDate = null
                 }
            );
        }
    }
}