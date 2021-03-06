﻿using EmployeeManage.Domain.Responses.Departments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.DAL.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> Gets();
        Task<Department> Get(int departmentId);
        Task<DeleteDepartmentResult> Delete(int departmentId);
        Task<SaveDepartmentResult> Save(Department request);
        Task<IEnumerable<Department>> Search(string keyword);
    }
}
