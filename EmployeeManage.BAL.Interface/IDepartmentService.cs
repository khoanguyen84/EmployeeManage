using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;

namespace EmployeeManage.BAL.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<Department> Gets();
        Department Get(int departmentId);
        DeleteDepartmentResult Delete(int departmentId);
        SaveDepartmentResult Save(Department request);
    }
}
