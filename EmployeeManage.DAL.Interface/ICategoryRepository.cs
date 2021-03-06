﻿using EmployeeManage.Domain.Requests.Categories;
using EmployeeManage.Domain.Responses.Categories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.DAL.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Gets();
        Task<Category> Get(int catId);
        Task<DeleteCategoryResult> Delete(int catId);
        Task<SaveCategoryResult> Save(SaveCategoryRequest request);
        Task<IEnumerable<Category>> Search(string keyword);
    }
}
