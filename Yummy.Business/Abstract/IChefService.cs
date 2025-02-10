using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IChefService : IGenericService<Chef>
    {
        Task TSetChefVisibleOnHome(int id);
        Task TSetChefHiddenOnHome(int id);
        void TToggleChefStatus(int id);
    }
}