using Newtonsoft.Json;

namespace UserManagement.WebUI.ViewModels
{
    public class SingleResponseData
    {
        public int StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public DepartmentVM Data { get; set; }
    }
}
