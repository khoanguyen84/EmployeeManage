using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses.Employee
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DoB { get; set; }
        public int Gender { get; set; }
        public string AvatarPath { get; set; }
        public int DepartmentId { get; set; }
    }
}
