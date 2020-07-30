using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests.Product;
using EmployeeManage.Domain.Responses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<DeleteProductResult> Delete(int productId)
        {
            return await productRepository.Delete(productId);
        }

        public async Task<ProductDetail> Get(int productId)
        {
            return await productRepository.Get(productId);
        }

        public async Task<IEnumerable<ProductView>> Gets(int catId)
        {
            return await productRepository.Gets(catId);
        }

        public async Task<SaveProductResult> Save(SaveProductRequest request)
        {
            return await productRepository.Save(request);
        }
    }
}
