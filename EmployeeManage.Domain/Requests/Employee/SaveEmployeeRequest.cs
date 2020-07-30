using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Requests.Employee
{
    public class SaveEmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DoB { get; set; }
        public int Gender { get; set; }
        public string AvatarPath { get; set; }
        public int DepartmentId { get; set; }
    }
}
