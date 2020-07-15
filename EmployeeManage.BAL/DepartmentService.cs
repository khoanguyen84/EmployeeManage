using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;

namespace EmployeeManage.BAL
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public DeleteDepartmentResult Delete(int departmentId)
        {
            return departmentRepository.Delete(departmentId);
        }

        public Department Get(int departmentId)
        {
            return departmentRepository.Get(departmentId);
        }

        public IEnumerable<Department> Gets()
        {
            return departmentRepository.Gets();
        }

        public SaveDepartmentResult Save(Department request)
        {
            return departmentRepository.Save(request);
        }
    }
}
