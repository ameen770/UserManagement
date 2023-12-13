using System;

namespace UserManagement.Domain.Constant
{
    public abstract class BaseModel
    {
        public DateTime? CreatedDate { get; set; }
        //public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public string? ModifiedBy { get; set; }
    }
}
