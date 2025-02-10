using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class ChefRepository : GenericRepository<Chef>, IChefRepository
    {
        public ChefRepository(YummyContext context) : base(context)
        {
        }

        public void ToggleChefStatus(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef.IsActive == true)
            {
                chef.IsActive = false;
                chef.IsVisible = false;
            }
            else
            {
                chef.IsActive = true;
            }
            _context.Update(chef);
            _context.SaveChanges();
        }

        public async Task SetChefVisibilityOnHome(int id, bool isVisible)
        {
            await _context.Chefs.Where(c => c.ChefID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetChefVisibleOnHome(int id)
        {
            await SetChefVisibilityOnHome(id, true); 
        }

        public async Task SetChefHiddenOnHome(int id)
        {
            await SetChefVisibilityOnHome(id, false);
        }
    }
}