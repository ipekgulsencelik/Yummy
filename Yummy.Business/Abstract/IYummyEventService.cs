using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IYummyEventService : IGenericService<YummyEvent>
    {
        Task TSetYummyEventVisibleOnHome(int id);
        Task TSetYummyEventHiddenOnHome(int id);
        void TToggleYummyEventStatus(int id);
    }
}