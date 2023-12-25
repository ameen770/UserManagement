using Newtonsoft.Json;

namespace UserManagement.WebUI.ViewModels
{
    public class DepartmentVM
    {
        [JsonProperty("Id")]
        public int DepartmentId { get; set; }
        [JsonProperty("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
