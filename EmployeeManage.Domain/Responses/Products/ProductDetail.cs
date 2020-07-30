using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses.Products
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
    }
}
