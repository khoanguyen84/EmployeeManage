using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Requests.Categories
{
    public class SaveCategoryRequest
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
