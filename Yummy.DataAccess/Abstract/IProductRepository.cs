using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task SetProductVisibleOnHome(int id);
        Task SetProductHiddenOnHome(int id);
        void ToggleProductStatus(int id);
    }
}