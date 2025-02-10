using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IRepository<Category> _repository, ICategoryRepository categoryRepository) : base(_repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task TSetCategoryHiddenOnHome(int id)
        {
            await _categoryRepository.SetCategoryHiddenOnHome(id);
        }

        public async Task TSetCategoryVisibleOnHome(int id)
        {
            await _categoryRepository.SetCategoryVisibleOnHome(id);
        }

        public void TToggleCategoryStatus(int id)
        {
            _categoryRepository.ToggleCategoryStatus(id);
        }
    }
}