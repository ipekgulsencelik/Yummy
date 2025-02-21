using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task SetContactVisibleOnHome(int id);
        Task SetContactHiddenOnHome(int id);
    }
}