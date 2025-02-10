using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task SetCategoryVisibleOnHome(int id);
        Task SetCategoryHiddenOnHome(int id);
        void ToggleCategoryStatus(int id);
    }
}