using Newtonsoft.Json;

namespace UserManagement.WebUI.ViewModels
{
    public class DepartmentVM
    {
        [JsonProperty("Id")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
