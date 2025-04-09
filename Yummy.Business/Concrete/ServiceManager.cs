using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class ServiceManager : GenericManager<Service>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IRepository<Service> _repository, IServiceRepository serviceRepository) : base(_repository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task TSetServiceHiddenOnHome(int id)
        {
            await _serviceRepository.SetServiceHiddenOnHome(id);
        }

        public async Task TSetServiceVisibleOnHome(int id)
        {
            await _serviceRepository.SetServiceVisibleOnHome(id);
        }

        public async Task TToggleServiceStatus(int id)
        {
            await _serviceRepository.ToggleServiceStatus(id);
        }
    }
}