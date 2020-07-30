using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Requests.Product
{
    public class SaveProductRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
