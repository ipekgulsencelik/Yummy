using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        Task TSetFeatureVisibleOnHome(int id);
        Task TSetFeatureHiddenOnHome(int id);
        void TToggleFeatureStatus(int id);
    }
}