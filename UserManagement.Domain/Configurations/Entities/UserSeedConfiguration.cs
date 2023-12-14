using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                 new AppUser
                 {
                     Id = 1,
                     FirstName = "Administrator",
                     LastName = "System",
                     Email = "administrator@administrator.com",
                     UserName = "administrator@administrator.com",
                     Password = "Administrator@123",
                     Status = Enum.UserStatus.Active,
                     DepartmentId = 1,
                     Department = null
                 },
                 new AppUser
                 {
                     Id = 2,
                     FirstName = "Admin",
                     LastName = "System",
                     Email = "admin@admin.com",
                     UserName = "admin@admin.com",
                     Password = "Admin@123",
                     Status = Enum.UserStatus.Active,
                     DepartmentId = 2,
                     Department = null 
                 },
                 new AppUser
                 {
                     Id = 3,
                     FirstName = "User",
                     LastName = "System",
                     Email = "user@user.com",
                     UserName = "user@user.com",
                     Password = "User@123",
                     Status = Enum.UserStatus.Active,
                     DepartmentId = 3,
                     Department = null
                 }
            );
        }
    }
}