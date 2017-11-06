using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
