using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task TShowOnHome(int id);
        Task TDontShowOnHome(int id);
        Task TChangeStatus(int id);
    }
}