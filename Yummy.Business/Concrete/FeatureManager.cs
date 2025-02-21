using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class FeatureManager : GenericManager<Feature>, IFeatureService
    {
        private readonly IFeatureRepository _chefRepository;

        public FeatureManager(IRepository<Feature> _repository, IFeatureRepository chefRepository) : base(_repository)
        {
            _chefRepository = chefRepository;
        }

        public async Task TSetFeatureHiddenOnHome(int id)
        {
            await _chefRepository.SetFeatureHiddenOnHome(id);
        }

        public async Task TSetFeatureVisibleOnHome(int id)
        {
            await _chefRepository.SetFeatureVisibleOnHome(id);
        }

        public void TToggleFeatureStatus(int id)
        {
            _chefRepository.ToggleFeatureStatus(id);
        }
    }
}