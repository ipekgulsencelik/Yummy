using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(YummyContext context) : base(context)
        {
        }

        public async Task ChangeStatus(int id)
        {
            await _context.Categories.Where(c => c.CategoryID == id).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsActive, x => !x.IsActive));
        }

        public async Task DontShowOnHome(int id)
        {
            await _context.Categories.Where(c => c.CategoryID == id).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, false));
        }

        public async Task ShowOnHome(int id)
        {
            await _context.Categories.Where(c => c.CategoryID == id).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, true));
        }
    }
}