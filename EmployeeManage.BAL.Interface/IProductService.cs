using EmployeeManage.Domain.Requests.Product;
using EmployeeManage.Domain.Responses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductView>> Gets(int catId);
        Task<ProductDetail> Get(int productId);
        Task<DeleteProductResult> Delete(int productId);
        Task<SaveProductResult> Save(SaveProductRequest request);
    }
}
