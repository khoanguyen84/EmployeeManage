using EmployeeManage.Domain.Requests.Employee;
using EmployeeManage.Domain.Responses.Departments;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using EmployeeManage.Domain.Responses.Employee;

namespace EmployeeManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        //private static int departId = 0;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult List(int departId)
        {
            ViewBag.Title = "Employee List";
            var department = new Department();
            department = ApiHelper<Department>.HttpGetAsync($"{Helper.ApiUrl}api/department/get/{departId}");
            if(department != null)
            {
                //departId = id;
                ViewBag.Department = department;
            }
            return View();
        }

        public JsonResult Gets(int departId)
        {
            var employees = new List<EmployeeView>();
            employees = ApiHelper<List<EmployeeView>>.HttpGetAsync($"{Helper.ApiUrl}api/employee/gets/{departId}");
            return Json(new { employees });
        }

        [Route("/Employee/Delete/{employeeId}")]
        public JsonResult Delete(int employeeId)
        {
            var result = new DeleteEmployeeResult();
            result = ApiHelper<DeleteEmployeeResult>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/employee/delete/{employeeId}",
                                                    "DELETE"
                                                );
            return Json(new { result });
        }
        [Route("/Employee/Get/{employeeId}")]
        public JsonResult Get(int employeeId)
        {
            var employee = new EmployeeDetail();
            employee = ApiHelper<EmployeeDetail>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/employee/get/{employeeId}"
                                                );
            return Json(new { employee });
        }

        public JsonResult Save([FromBody] SaveEmployeeRequest model)
        {
            var result = new SaveEmployeeResult();
            result = ApiHelper<SaveEmployeeResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/employee/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
