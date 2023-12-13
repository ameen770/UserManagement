using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Enum;

namespace UserManagement.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
