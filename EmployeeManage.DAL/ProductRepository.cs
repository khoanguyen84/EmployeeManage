using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests.Employee;
using EmployeeManage.Domain.Requests.Product;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using EmployeeManage.Domain.Responses.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeManage.DAL
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public async Task<DeleteProductResult> Delete(int productId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductId", productId);
                return await SqlMapper.QueryFirstOrDefaultAsync<DeleteProductResult>(cnn: conn,
                                 param: parameters,
                                sql: "sp_DeleteProduct",
                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                return new DeleteProductResult() { 

                };
            }
            
        }

        public async Task<ProductDetail> Get(int productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<ProductDetail>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetProduct",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<ProductView>> Gets(int catId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryId", catId);
            return await SqlMapper.QueryAsync<ProductView>(cnn: conn,
                        param: parameters,
                        sql: "sp_GetProductsByCatId",
                        commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveProductResult> Save(SaveProductRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductId", request.ProductId);
                parameters.Add("@ProductName", request.ProductName);
                parameters.Add("@Price", request.Price);
                parameters.Add("@CategoryId", request.CategoryId);
                parameters.Add("@Image", request.Image);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveProductResult>(cnn: conn,
                                            sql: "sp_SaveProduct",
                                            param: parameters,
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                return new SaveProductResult()
                {
                    ProductId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }
    }
}
