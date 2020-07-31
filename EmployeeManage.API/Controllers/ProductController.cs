using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain.Requests.Product;
using EmployeeManage.Domain.Responses.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<DepartmentController> _logger;
        private readonly IProductService productService;

        public ProductController(ILogger<DepartmentController> logger,
                                    IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        /// <summary>
        /// Get products by catId
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/product/gets/{catId}")]
        public async Task<IEnumerable<ProductView>> Gets(int catId)
        {
            return await productService.Gets(catId);
        }

        /// <summary>
        /// Get product by productId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/product/get/{id}")]
        public async Task<ProductDetail> Get(int id)
        {
            return await productService.Get(id);
        }

        [HttpPost]
        [Route("/api/product/save")]
        public async Task<SaveProductResult> Save(SaveProductRequest request)
        {
            return await productService.Save(request);
        }

        [HttpDelete]
        [Route("/api/product/delete/{id}")]
        public async Task<DeleteProductResult> Delete(int id)
        {
            return await productService.Delete(id);
        }
    }
}
