using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Task TSetContactVisibleOnHome(int id);
        Task TSetContactHiddenOnHome(int id);
    }
}