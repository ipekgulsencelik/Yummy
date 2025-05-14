using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class YummyEventManager : GenericManager<YummyEvent>, IYummyEventService
    {
        private readonly IYummyEventRepository _organizationRepository;

        public YummyEventManager(IRepository<YummyEvent> _repository, IYummyEventRepository organizationRepository) : base(_repository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task TSetYummyEventHiddenOnHome(int id)
        {
            await _organizationRepository.SetYummyEventHiddenOnHome(id);
        }

        public async Task TSetYummyEventVisibleOnHome(int id)
        {
            await _organizationRepository.SetYummyEventVisibleOnHome(id);
        }

        public void TToggleYummyEventStatus(int id)
        {
            _organizationRepository.ToggleYummyEventStatus(id);
        }
    }
}