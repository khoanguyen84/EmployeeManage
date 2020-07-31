using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests.Categories;
using EmployeeManage.Domain.Responses.Categories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManage.DAL
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public async Task<DeleteCategoryResult> Delete(int catId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryId", catId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteCategoryResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_DeleteCategory",
                            commandType: CommandType.StoredProcedure);
        }

        public async Task<Category> Get(int catId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryId", catId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Category>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetCategory", 
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await SqlMapper.QueryAsync<Category>(conn, "sp_GetCategories", CommandType.StoredProcedure);
        }

        public async Task<SaveCategoryResult> Save(SaveCategoryRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CategoryId", request.CategoryId);
                parameters.Add("@CategoryName", request.CategoryName);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveCategoryResult>(cnn: conn, 
                                            sql: "sp_SaveCategory",
                                            param: parameters, 
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                return new SaveCategoryResult()
                {
                    CategoryId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }

        public async Task<IEnumerable<Category>> Search(string keyword)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@keyword", keyword);
            return await SqlMapper.QueryAsync<Category>(cnn: conn, sql: "sp_SearchCategory",
                                               param: parameters,
                                               commandType: CommandType.StoredProcedure);
        }
    }
}
