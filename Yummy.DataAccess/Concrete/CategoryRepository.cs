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

        public void ToggleCategoryStatus(int id)
        {
            var category = _context.Categories.Find(id);
            if (category.IsActive == true)
            {
                category.IsActive = false;
                category.IsVisible = false;
            }
            else
            {
                category.IsActive = true;
            }
            _context.Update(category);
            _context.SaveChanges();
        }

        public async Task SetCategoryHiddenOnHome(int id)
        {
            await _context.Categories.Where(c => c.CategoryID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, false));
        }

        public async Task SetCategoryVisibleOnHome(int id)
        {
            await _context.Categories.Where(c => c.CategoryID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, true));
        }
    }
}