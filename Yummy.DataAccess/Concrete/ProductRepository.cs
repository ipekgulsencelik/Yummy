using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(YummyContext context) : base(context)
        {
        }

        public void ToggleProductStatus(int id)
        {
            var product = _context.Products.Find(id);
            if (product.IsActive == true)
            {
                product.IsActive = false;
                product.IsVisible = false;
            }
            else
            {
                product.IsActive = true;
            }
            _context.Update(product);
            _context.SaveChanges();
        }

        public async Task SetProductHiddenOnHome(int id)
        {
            await _context.Products.Where(p => p.ProductID == id && p.IsActive).ExecuteUpdateAsync(p => p.SetProperty(x => x.IsVisible, false));
        }

        public async Task SetProductVisibleOnHome(int id)
        {
            await _context.Products.Where(p => p.ProductID == id && p.IsActive).ExecuteUpdateAsync(p => p.SetProperty(x => x.IsVisible, true));
        }
    }
}