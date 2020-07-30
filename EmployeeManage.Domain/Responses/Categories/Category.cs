using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses.Categories
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Products { get; set; }
    }
}
