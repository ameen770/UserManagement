using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement.WebUI.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserManagement.WebUI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly HttpClient _httpClient;
        //HttpClient _client = new HttpClient();
        private string BaseURL = "https://localhost:7186/Api/V1/Department/";

        public DepartmentsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<ActionResult> Index()
        {
            List<DepartmentVM> departments = new List<DepartmentVM>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(BaseURL + "List");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // departments = JsonConvert.DeserializeObject<List<Student>>(responseContent);
                    ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(responseContent);
                    departments = responseData.Data;
                    return View(departments);
                }

                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            DepartmentVM department = new DepartmentVM();
            HttpResponseMessage responseUrl = await _httpClient.GetAsync(BaseURL + id);
            if (responseUrl.IsSuccessStatusCode)
            {
                string data = await responseUrl.Content.ReadAsStringAsync();
                SingleResponseData responseData = JsonConvert.DeserializeObject<SingleResponseData>(data);
                department = responseData.Data;
                return View(department);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentVM department)
        {   
            if (!ModelState.IsValid)
            {
                /*SingleResponseData singleResponseData = new SingleResponseData()
                {
                    StatusCode = responseData.StatusCode,
                    Meta = responseData.Meta,
                    Succeeded = responseData.Succeeded,
                    Message = responseData.Message,
                    Errors = responseData.Errors,
                    Data = responseData.Data
                };

                DepartmentVM departmentToCreate = new DepartmentVM
                {
                    DepartmentName = department.DepartmentName
                };
                responseData.Data = departmentToCreate;*/


                return View("Error");

            }
            else
            {
                SingleResponseData responseData = new SingleResponseData
                {
                    Data = department
                };
                string data = JsonConvert.SerializeObject(responseData);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await _httpClient.PostAsync(BaseURL + "Create", content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            DepartmentVM departmentVM = new DepartmentVM();
            HttpResponseMessage responseUrl = await _httpClient.GetAsync(BaseURL + id);
            if (responseUrl.IsSuccessStatusCode)
            {
                string data = await responseUrl.Content.ReadAsStringAsync();
                SingleResponseData responseData = JsonConvert.DeserializeObject<SingleResponseData>(data);
                departmentVM = responseData.Data;
                return View(departmentVM);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentVM department)
        {

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                DepartmentVM departmentToCreate = new DepartmentVM
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName
                };

                string data = JsonConvert.SerializeObject(departmentToCreate);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await _httpClient.PutAsync(BaseURL + "Edit", content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            DepartmentVM departmentVM = new DepartmentVM();
            HttpResponseMessage responseUrl = await _httpClient.GetAsync(BaseURL + id);
            if (responseUrl.IsSuccessStatusCode)
            {
                string data = await responseUrl.Content.ReadAsStringAsync();
                SingleResponseData responseData = JsonConvert.DeserializeObject<SingleResponseData>(data);
                departmentVM = responseData.Data;
                return View(departmentVM);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(BaseURL + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
