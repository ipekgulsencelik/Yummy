using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task SetFeatureVisibleOnHome(int id);
        Task SetFeatureHiddenOnHome(int id);
        void ToggleFeatureStatus(int id);
    }
}