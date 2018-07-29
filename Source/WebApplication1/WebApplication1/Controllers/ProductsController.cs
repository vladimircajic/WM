using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        public ProductViewModels ProductModel { get; private set; }

        public ProductsController()
        {
           
            ProductModel = new ProductViewModels();
            var productCategories = GetProductCategories();
            ProductModel.ProductCategories = productCategories;
        }

        private List<ProductCategory> GetProductCategories()
        {
            var result = new List<ProductCategory>();


            using (WMEntities db = new WMEntities())
            {
                result = db.ProductCategories.ToList();
            }
            return result;
        }

        // GET: Produts
        public ActionResult Index()
        {
            return View(ProductModel);
        }

        // GET: Produts
        public ActionResult LoadProductsDb()
        {
            var products = new List<ProductModel>();

            using (WMEntities db = new WMEntities())
            {
                var dbProducts = db.Products;
                foreach (var item in dbProducts)
                {
                    products.Add(new ProductModel()
                    {
                        Id = item.Id,
                        Name= item.Name,
                        Price = item.Price,
                        Producer = item.Producer,
                        ProductCategoryName = item.ProductCategory?.Name,
                        ProductCategoryId = item.ProductCategoryId,
                        Supplier = item.Supplier  
                    });
                }
              
            }


            ProductModel.Products = products;
            return View(ProductModel);
        }

        // GET: Produts
        public ActionResult LoadProductsJson()
        {
            var products = new List<ProductModel>();
            var path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<ProductModel> items = JsonConvert.DeserializeObject<List<ProductModel>>(json);
                products = items;
            }
            ProductModel.Products = products;
            return View(ProductModel);
        }

        // GET: Produts
        public ActionResult AddProduct()
        {
            var products = new List<ProductModel>();

            using (WMEntities db = new WMEntities())
            {
                var dbProducts = db.Products;
                foreach (var item in dbProducts)
                {
                    products.Add(new ProductModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Producer = item.Producer,
                        ProductCategoryName = item.ProductCategory?.Name,
                        ProductCategoryId = item.ProductCategoryId,
                        Supplier = item.Supplier
                    });
                }

            }


            ProductModel.Products = products;
            return View(ProductModel);
        }

        [HttpPost]
        public ActionResult AddProductAction(AddProductModel pm)
        {
            using (WMEntities db = new WMEntities())
            {
               db.Products.Add(new Product() {
                   Name = pm.Name,
                   Price = pm.Price,
                   Producer = pm.Producer,
                   ProductCategoryId = pm.CategoryId,
                   Supplier = pm.Supplier
               });

                db.SaveChanges();
            }

            return Json("OK");
        }

        [HttpPost]
        public ActionResult EditProductAction(AddProductModel pm)
        {
            using (WMEntities db = new WMEntities())
            {
                var p = db.Products.Where(x=>x.Id == pm.Id).FirstOrDefault();
                p.Name = pm.Name;
                p.Price = pm.Price;
                p.Producer = pm.Producer;
                p.ProductCategoryId = pm.CategoryId;
                p.Supplier = pm.Supplier;

                db.SaveChanges();
            }

            return Json("OK");
        }
        public ActionResult EditProductMain(int id)

        {

            ProductModel.Products = new List<ProductModel>();
            var products = new List<ProductModel>();

            using (WMEntities db = new WMEntities())
            {
                var dbProducts = db.Products.Where(x=>x.Id == id);
                foreach (var item in dbProducts)
                {
                    products.Add(new ProductModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Producer = item.Producer,
                        ProductCategoryName = item.ProductCategory?.Name,
                        ProductCategoryId = item.ProductCategoryId,
                        Supplier = item.Supplier
                    });
                }

            }

            ProductModel.Products = products;

            return View(ProductModel);

        }

        

        public ActionResult EditProduct()
        {
            var products = new List<ProductModel>();

            using (WMEntities db = new WMEntities())
            {
                var dbProducts = db.Products;
                foreach (var item in dbProducts)
                {
                    products.Add(new ProductModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Producer = item.Producer,
                        ProductCategoryName = item.ProductCategory?.Name,
                        ProductCategoryId = item.ProductCategoryId,
                        Supplier = item.Supplier
                    });
                }

            }


            ProductModel.Products = products;
            return View(ProductModel);
        }

        private List<Product> GetProducts()
        {
            var result = new List<Product>();

            return result;
        }

        private ProductCategory GetProductCategory(int categoryId)
        {
            var result = null as ProductCategory;
            return result;
        }

        private int GetId()
        {
            var result = -1;

            return result;
        }
    }

}