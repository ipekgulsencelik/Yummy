using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IRepository<Product> _repository, IProductRepository productRepository) : base(_repository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> TGetProductsWithCategory()
        {
            return await _productRepository.GetProductsWithCategory();
        }

        public async Task TSetProductHiddenOnHome(int id)
        {
            await _productRepository.SetProductHiddenOnHome(id);
        }

        public async Task TSetProductVisibleOnHome(int id)
        {
            await _productRepository.SetProductVisibleOnHome(id);
        }

        public void TToggleProductStatus(int id)
        {
            _productRepository.ToggleProductStatus(id);
        }
    }
}