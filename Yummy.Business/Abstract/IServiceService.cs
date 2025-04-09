using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IServiceService : IGenericService<Service>
    {
        Task TSetServiceVisibleOnHome(int id);
        Task TSetServiceHiddenOnHome(int id);
        Task TToggleServiceStatus(int id);
    }
}