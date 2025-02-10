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

        public async Task TDontShowOnHome(int id)
        {
            await _categoryRepository.DontShowOnHome(id);
        }

        public async Task TShowOnHome(int id)
        {
            await _categoryRepository.ShowOnHome(id);
        }

        public async Task TChangeStatus(int id)
        {
            await _categoryRepository.ChangeStatus(id);
        }
    }
}