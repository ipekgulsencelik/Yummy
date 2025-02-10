using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task ShowOnHome(int id);
        Task DontShowOnHome(int id);
        Task ChangeStatus(int id);
    }
}