using ProductMicroservicesProject.Models;

namespace ProductMicroservicesProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbcontext;
        public ProductRepository(AppDbContext context) { _dbcontext = context; }
        public void DeleteProduct(int id)
        {
            var product = _dbcontext.Products.Find(id);
            _dbcontext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int id)
        {
            return _dbcontext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbcontext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbcontext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }   
    }
}
