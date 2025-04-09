using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task SetServiceVisibleOnHome(int id);
        Task SetServiceHiddenOnHome(int id);
        Task ToggleServiceStatus(int id);
    }
}