using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Constant;

namespace UserManagement.Domain.Entities
{
    public class Department : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppUser>? AppUsers { get; set; } = new List<AppUser>();
    }
}
