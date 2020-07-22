using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        //public async Task<DeleteDepartmentResult> Delete(int departmentId)
        //{
        //    return await departmentRepository.Delete(departmentId);
        //}

        //public async Task<Department> Get(int departmentId)
        //{
        //    return await departmentRepository.Get(departmentId);
        //}

        public async Task<IEnumerable<EmployeeView>> Gets(int departId)
        {
            return await employeeRepository.Gets(departId);
        }

        //public async Task<SaveDepartmentResult> Save(Department request)
        //{
        //    return await departmentRepository.Save(request);
        //}

        //public async Task<IEnumerable<Department>> Search(string keyword)
        //{
        //    return await departmentRepository.Search(keyword);
        //}
    }
}
