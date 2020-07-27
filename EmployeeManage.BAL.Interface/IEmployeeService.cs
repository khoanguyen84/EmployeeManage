﻿using EmployeeManage.Domain.Requests;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeView>> Gets(int departId);
        Task<EmployeeDetail> Get(int employeeId);
        Task<DeleteEmployeeResult> Delete(int employeeId);
        Task<SaveEmployeeResult> Save(SaveEmployeeRequest request);
        //Task<IEnumerable<Department>> Search(string keyword);
    }
}
