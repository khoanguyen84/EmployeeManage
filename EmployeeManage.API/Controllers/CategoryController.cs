using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain.Requests.Categories;
using EmployeeManage.Domain.Responses.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger,
                                    ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Get all category in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/category/gets")]
        public async Task<IEnumerable<Category>> Gets()
        {
            return await categoryService.Gets();
        }

        /// <summary>
        /// Get category by categoryid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/category/get/{id}")]
        public async Task<Category> Get(int id)
        {
            return await categoryService.Get(id);
        }

        [HttpPost]
        [Route("/api/category/save")]
        public async Task<SaveCategoryResult> Save(SaveCategoryRequest request)
        {
            return await categoryService.Save(request);
        }

        [HttpDelete]
        [Route("/api/category/delete/{id}")]
        public async Task<DeleteCategoryResult> Delete(int id)
        {
            return await categoryService.Delete(id);
        }

        [HttpGet("/api/category/search")]
        public async Task<IEnumerable<Category>> Search(string keyword)
        {
            return  await categoryService.Search(keyword);
        }
    }
}
