using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;

namespace EmployeeManage.DAL.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Gets();
        Department Get(int departmentId);
        bool Delete(int departmentId);
        int Save(Department request);
    }
}
