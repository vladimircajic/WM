using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class ProductViewModels
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}