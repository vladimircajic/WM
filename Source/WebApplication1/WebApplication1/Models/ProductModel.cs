using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Producer { get; set; }
        public string Supplier { get; set; }
        public double? Price { get; set; }


    }
}