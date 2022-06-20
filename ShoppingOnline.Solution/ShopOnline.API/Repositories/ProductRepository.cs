using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.Repositories.Contracts;

namespace ShopOnline.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Inject DBContext Class
        private ShopOnlineDbContext ShopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext _shopOnlineDbContext)
        {
            this.ShopOnlineDbContext = _shopOnlineDbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.ShopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await this.ShopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.ShopOnlineDbContext.Products.ToListAsync();
            //.Include(p => p.ProductCategory).ToListAsync(); -> To Optimize
            return products;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await this.ShopOnlineDbContext.Products.FindAsync(id);//.Where(c => c.Id == id).FirstOrDefaultAsync();
            return product;
        }
    }
}
