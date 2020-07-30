using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses.Products
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
