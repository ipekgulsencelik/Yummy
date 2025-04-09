using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(YummyContext context) : base(context)
        {
        }

        public async Task ToggleServiceStatus(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service.IsActive == true)
            {
                service.IsActive = false;
                service.IsVisible = false;
            }
            else
            {
                service.IsActive = true;
            }
            _context.Update(service);
            _context.SaveChanges();
        }

        public async Task SetServiceVisibilityOnHome(int id, bool isVisible)
        {
            await _context.Services.Where(c => c.ServiceID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetServiceVisibleOnHome(int id)
        {
            await SetServiceVisibilityOnHome(id, true);
        }

        public async Task SetServiceHiddenOnHome(int id)
        {
            await SetServiceVisibilityOnHome(id, false);
        }
    }
}