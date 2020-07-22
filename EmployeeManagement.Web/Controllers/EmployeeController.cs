using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using EmployeeManage.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        //public JsonResult Delete(int id)
        //{
        //    var result = new DeleteDepartmentResult();
        //    result = ApiHelper<DeleteDepartmentResult>.HttpGetAsync(
        //                                            $"{Helper.ApiUrl}api/department/delete/{id}",
        //                                            "DELETE"
        //                                        );
        //    return Json(new { result });
        //}

        //public JsonResult Get(int id)
        //{
        //    var result = new Department();
        //    result = ApiHelper<Department>.HttpGetAsync(
        //                                            $"{Helper.ApiUrl}api/department/get/{id}"
        //                                        );
        //    return Json(new { result });
        //}

        //public JsonResult Save([FromBody] Department model)
        //{
        //    var result = new SaveDepartmentResult();
        //    result = ApiHelper<SaveDepartmentResult>.HttpPostAsync(
        //                                            $"{Helper.ApiUrl}api/department/save",
        //                                            model
        //                                        );
        //    return Json(new { result });
        //}
    }
}
