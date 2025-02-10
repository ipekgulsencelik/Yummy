using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class ChefManager : GenericManager<Chef>, IChefService
    {
        private readonly IChefRepository _chefRepository;

        public ChefManager(IRepository<Chef> _repository, IChefRepository chefRepository) : base(_repository)
        {
            _chefRepository = chefRepository;
        }

        public async Task TSetChefHiddenOnHome(int id)
        {
            await _chefRepository.SetChefHiddenOnHome(id);
        }

        public async Task TSetChefVisibleOnHome(int id)
        {
            await _chefRepository.SetChefVisibleOnHome(id);
        }

        public void TToggleChefStatus(int id)
        {
            _chefRepository.ToggleChefStatus(id);
        }
    }
}