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
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                 new AppUser
                 {
                     Id = "b1a6d8c4-9e7f-4d20-aae3-6f1b2c9d5e5a",
                     Email = "administrator@administrator.com",
                     NormalizedEmail = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     NormalizedUserName = "ADMINISTRATOR@ADMINISTRATOR.COM",
                     UserName = "administrator@administrator.com",
                     FirstName = "Administrator",
                     LastName = "System",
                     DepartmentId = 1,
                     Department = null,
                     Status = Enum.UserStatus.Active,
                     PasswordHash = hasher.HashPassword(null, "Administrator@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "f8c6a9d2-5e4f-4b10-9e1d-3c7b8a6f9d2c",
                     Email = "admin@admin.com",
                     NormalizedEmail = "ADMIN@ADMIN.COM",
                     NormalizedUserName = "ADMIN@ADMIN.COM",
                     UserName = "admin@admin.com",
                     FirstName = "Admin",
                     LastName = "System",
                     DepartmentId = 2,
                     Department = null,
                     Status = Enum.UserStatus.Active,
                     PasswordHash = hasher.HashPassword(null, "Admin@123"),
                     EmailConfirmed = true
                 },
                 new AppUser
                 {
                     Id = "d3e8c5b9-1a2b-4c3d-8e9f-5a6b7c8d9e0f",
                     Email = "user@user.com",
                     NormalizedEmail = "USER@USER.COM",
                     NormalizedUserName = "USER@USER.COM",
                     UserName = "user@user.com",
                     FirstName = "User",
                     LastName = "System",
                     DepartmentId = 3,
                     Department = null,
                     Status = Enum.UserStatus.Active,
                     PasswordHash = hasher.HashPassword(null, "User@123"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}