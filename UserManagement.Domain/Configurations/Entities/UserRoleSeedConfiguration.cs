using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.Domain.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8f6f8ed7-2c3b-4e10-a7c6-3a8b9d7f9b4a",
                    UserId = "b1a6d8c4-9e7f-4d20-aae3-6f1b2c9d5e5a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "e5deabf1-8e2c-4f06-af4d-9f0a56f7d89d",
                    UserId = "f8c6a9d2-5e4f-4b10-9e1d-3c7b8a6f9d2c"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "a1d7e4c2-3f05-4a88-94c5-7e5f9b8d6e9b",
                    UserId = "d3e8c5b9-1a2b-4c3d-8e9f-5a6b7c8d9e0f"
                }
            );
        }
    }
}