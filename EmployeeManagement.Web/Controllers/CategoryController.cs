using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement.Web.Models;
using EmployeeManage.Domain.Responses.Categories;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using EmployeeManage.Web.Ultilities;
using EmployeeManage.Domain.Requests.Categories;

namespace EmployeeManagement.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Category List";
            return View();
        }

        public JsonResult Gets()
        {
            var categories = new List<Category>();
            categories = ApiHelper<List<Category>>.HttpGetAsync($"{Helper.ApiUrl}api/category/gets");
            return Json(new { categories });
        }

        [Route("/Category/Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = new DeleteCategoryResult();
            result = ApiHelper<DeleteCategoryResult>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/category/delete/{id}",
                                                    "DELETE"
                                                );
            return Json(new { result });
        }

        [Route("/Category/Get/{id}")]
        public JsonResult Get(int id)
        {
            var result = new Category();
            result = ApiHelper<Category>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/category/get/{id}"
                                                );
            return Json(new { result });
        }

        public JsonResult Save([FromBody] SaveCategoryRequest model)
        {
            var result = new SaveCategoryResult();
            result = ApiHelper<SaveCategoryResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/category/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
