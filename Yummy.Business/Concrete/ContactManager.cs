using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class ContactManager : GenericManager<Contact>, IContactService
    {
        private readonly IContactRepository _chefRepository;

        public ContactManager(IRepository<Contact> _repository, IContactRepository chefRepository) : base(_repository)
        {
            _chefRepository = chefRepository;
        }

        public async Task TSetContactHiddenOnHome(int id)
        {
            await _chefRepository.SetContactHiddenOnHome(id);
        }

        public async Task TSetContactVisibleOnHome(int id)
        {
            await _chefRepository.SetContactVisibleOnHome(id);
        }
    }
}