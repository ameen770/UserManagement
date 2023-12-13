using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.Domain.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "8f6f8ed7-2c3b-4e10-a7c6-3a8b9d7f9b4a",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "e5deabf1-8e2c-4f06-af4d-9f0a56f7d89d",
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "a1d7e4c2-3f05-4a88-94c5-7e5f9b8d6e9b",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
            );
        }
    }
}
