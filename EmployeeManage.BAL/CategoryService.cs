using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests.Categories;
using EmployeeManage.Domain.Responses.Categories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<DeleteCategoryResult> Delete(int catId)
        {
            return await categoryRepository.Delete(catId);
        }

        public async Task<Category> Get(int catId)
        {
            return await categoryRepository.Get(catId);
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await categoryRepository.Gets();
        }

        public async Task<SaveCategoryResult> Save(SaveCategoryRequest request)
        {
            return await categoryRepository.Save(request);
        }

        public async Task<IEnumerable<Category>> Search(string keyword)
        {
            return await categoryRepository.Search(keyword);
        }
    }
}
