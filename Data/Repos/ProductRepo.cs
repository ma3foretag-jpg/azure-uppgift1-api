using Azure_uppgift1_API.Data.Entites;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics;

namespace Azure_uppgift1_API.Data.Repos
{
    public class ProductRepo
    {
        private readonly AppDBContext _dbContext;

        public ProductRepo(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Product?> AddProduct(Product product)
        {

            if (product == null)
                return null;


            var existP = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existP != null)
                return null;


            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var existp = await _dbContext.Products.FindAsync(id);

            if (existp == null)
                return false;

            _dbContext.Remove(existp);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        
    }
}
