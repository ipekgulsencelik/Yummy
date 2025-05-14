using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IYummyEventRepository : IRepository<YummyEvent>
    {
        Task SetYummyEventVisibleOnHome(int id);
        Task SetYummyEventHiddenOnHome(int id);
        Task ToggleYummyEventStatus(int id);
    }
}