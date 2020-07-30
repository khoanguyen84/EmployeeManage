using EmployeeManage.Domain.Requests.Product;
using EmployeeManage.Domain.Responses.Categories;
using EmployeeManage.Domain.Responses.Departments;
using EmployeeManage.Domain.Responses.Products;
using EmployeeManage.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [Route("/Product/List/{catId}")]
        public IActionResult List(int catId)
        {
            ViewBag.Title = "Product List";
            var category = new Category();
            category = ApiHelper<Category>.HttpGetAsync($"{Helper.ApiUrl}api/category/get/{catId}");
            if(category != null)
            {
                ViewBag.Category = category;
            }
            return View();
        }

        [Route("/Product/Gets/{catId}")]
        public JsonResult Gets(int catId)
        {
            var products = new List<ProductView>();
            products = ApiHelper<List<ProductView>>.HttpGetAsync($"{Helper.ApiUrl}api/product/gets/{catId}");
            return Json(new { products });
        }

        [Route("/Product/Delete/{productId}")]
        public JsonResult Delete(int productId)
        {
            var result = new DeleteProductResult();
            result = ApiHelper<DeleteProductResult>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/product/delete/{productId}",
                                                    "DELETE"
                                                );
            return Json(new { result });
        }
        [Route("/Product/Get/{productId}")]
        public JsonResult Get(int productId)
        {
            var product = new ProductDetail();
            product = ApiHelper<ProductDetail>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/product/get/{productId}"
                                                );
            return Json(new { product });
        }

        public JsonResult Save([FromBody] SaveProductRequest model)
        {
            var result = new SaveProductResult();
            result = ApiHelper<SaveProductResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/product/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
