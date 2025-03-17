using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task TSetProductVisibleOnHome(int id);
        Task TSetProductHiddenOnHome(int id);
        void TToggleProductStatus(int id);
        Task<List<Product>> TGetProductsWithCategory();
    }
}