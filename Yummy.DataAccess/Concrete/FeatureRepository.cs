using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(YummyContext context) : base(context)
        {
        }

        public void ToggleFeatureStatus(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature.IsActive == true)
            {
                feature.IsActive = false;
                feature.IsVisible = false;
            }
            else
            {
                feature.IsActive = true;
            }
            _context.Update(feature);
            _context.SaveChanges();
        }

        public async Task SetFeatureVisibilityOnHome(int id, bool isVisible)
        {
            await _context.Features.Where(c => c.FeatureID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetFeatureVisibleOnHome(int id)
        {
            await SetFeatureVisibilityOnHome(id, true);
        }

        public async Task SetFeatureHiddenOnHome(int id)
        {
            await SetFeatureVisibilityOnHome(id, false);
        }
    }
}