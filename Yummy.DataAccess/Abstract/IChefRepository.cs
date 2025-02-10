using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IChefRepository : IRepository<Chef>
    {
        Task SetChefVisibleOnHome(int id);
        Task SetChefHiddenOnHome(int id);
        void ToggleChefStatus(int id);
    }
}