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
        public bool Delete(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Department Get(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Gets()
        {
            return departmentRepository.Gets();
        }

        public int Save(Department request)
        {
            throw new NotImplementedException();
        }
    }
}
