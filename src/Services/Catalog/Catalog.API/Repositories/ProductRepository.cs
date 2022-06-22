using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return (await _catalogContext.Products.FindAsync(x => true)).ToEnumerable();
        }

        public async Task<Product> GetProduct(string id)
        {
            return (await _catalogContext.Products.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return (await _catalogContext.Products.FindAsync(Builders<Product>.Filter.Eq(p => p.Category, categoryName))).ToEnumerable();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return (await _catalogContext.Products.FindAsync(Builders<Product>.Filter.Eq(p => p.Name, name))).ToEnumerable();
        }

        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _catalogContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteResult = await _catalogContext.Products.DeleteOneAsync(Builders<Product>.Filter.Eq(p => p.Id, id));

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
