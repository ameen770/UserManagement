using Newtonsoft.Json;

namespace UserManagement.WebUI.ViewModels
{
    public class UserVM
    {
        //[JsonProperty("Id")]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
