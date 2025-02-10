using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task TSetCategoryVisibleOnHome(int id);
        Task TSetCategoryHiddenOnHome(int id);
        void TToggleCategoryStatus(int id);
    }
}