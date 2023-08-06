using MyWorkProject.Models;

namespace MyWorkProject.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new () { Id = 1, Name = "Lenovo", Description = "PC", Price = 20000, Stock = 1000, Barcode = 12345678 },
            new () { Id = 2, Name = "iPhone X", Description = "Phone", Price = 150000, Stock = 1000, Barcode = 59862656 },
            new () { Id = 3, Name = "Sony", Description = "PlayStation 5", Price = 40000, Stock = 1000, Barcode = 78243639 },
            new () { Id = 4, Name = "Beats", Description = "Earphones", Price = 5000, Stock = 1000, Barcode = 98564777 }

        };

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır.");
            }
            _products.Remove(hasProduct);
        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Description = updateProduct.Description;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;
            hasProduct.Barcode = updateProduct.Barcode;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }
    }
}
