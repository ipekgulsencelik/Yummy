using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(YummyContext context) : base(context)
        {
        }

        public async Task SetContactVisibilityOnHome(int id, bool isVisible)
        {
            await _context.Contacts.Where(c => c.ContactID == id).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetContactVisibleOnHome(int id)
        {
            await SetContactVisibilityOnHome(id, true);
        }

        public async Task SetContactHiddenOnHome(int id)
        {
            await SetContactVisibilityOnHome(id, false);
        }
    }
}