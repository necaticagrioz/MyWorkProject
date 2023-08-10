using Microsoft.AspNetCore.Mvc;
using MyWorkProject.Models;
using NuGet.Protocol.Core.Types;

namespace MyWorkProject.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context)
        {
            //DI Container
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();
            _context = context;

        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(Product newProduct)
        {

            //1.Yöntem
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var description = (HttpContext.Request.Form["description"].ToString());
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["stock"].ToString());
            //var barcode = int.Parse(HttpContext.Request.Form["Barcode"].ToString());

            //2.Yöntem
            //Product newProduct = new Product() { Name = name, Description = description, Price = price, Stock = stock, Barcode =  barcode };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["Status"] = "Ürün Başarıyla Eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);   
        }
        [HttpPost]
        public IActionResult Update(Product updateProdutct) 
        {
            _context.Products.Update(updateProdutct);
            _context.SaveChanges();
            TempData["Status"] = "Ürün Başarıyla Güncellendi";
            return RedirectToAction("Index");
        }
    }
}
