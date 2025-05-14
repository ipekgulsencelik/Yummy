using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class YummyEventRepository : GenericRepository<YummyEvent>, IYummyEventRepository
    {
        public YummyEventRepository(YummyContext context) : base(context)
        {
        }

        public async Task ToggleYummyEventStatus(int id)
        {
            var organization = await _context.YummyEvents.FindAsync(id);
            if (organization.IsActive == true)
            {
                organization.IsActive = false;
                organization.IsVisible = false;
            }
            else
            {
                organization.IsActive = true;
            }
            _context.Update(organization);
            _context.SaveChanges();
        }

        public async Task SetYummyEventVisibilityOnHome(int id, bool isVisible)
        {
            await _context.YummyEvents.Where(c => c.YummyEventID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetYummyEventVisibleOnHome(int id)
        {
            await SetYummyEventVisibilityOnHome(id, true);
        }

        public async Task SetYummyEventHiddenOnHome(int id)
        {
            await SetYummyEventVisibilityOnHome(id, false);
        }
    }
}