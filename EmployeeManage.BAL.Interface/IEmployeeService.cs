using EmployeeManage.Domain.Responses.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeView>> Gets(int departId);
        //Task<Department> Get(int departmentId);
        //Task<DeleteDepartmentResult> Delete(int departmentId);
        //Task<SaveDepartmentResult> Save(Department request);
        //Task<IEnumerable<Department>> Search(string keyword);
    }
}
