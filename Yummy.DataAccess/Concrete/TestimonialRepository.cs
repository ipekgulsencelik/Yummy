using Microsoft.EntityFrameworkCore;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Context;
using Yummy.DataAccess.Repositories;
using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Concrete
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(YummyContext context) : base(context)
        {
        }

        public async Task ToggleTestimonialStatus(int id)
        {
            var service = await _context.Testimonials.FindAsync(id);
            if (service.IsActive == true)
            {
                service.IsActive = false;
                service.IsVisible = false;
            }
            else
            {
                service.IsActive = true;
            }
            _context.Update(service);
            _context.SaveChanges();
        }

        public async Task SetTestimonialVisibilityOnHome(int id, bool isVisible)
        {
            await _context.Testimonials.Where(c => c.TestimonialID == id && c.IsActive).ExecuteUpdateAsync(c => c.SetProperty(x => x.IsVisible, isVisible));
        }

        public async Task SetTestimonialVisibleOnHome(int id)
        {
            await SetTestimonialVisibilityOnHome(id, true);
        }

        public async Task SetTestimonialHiddenOnHome(int id)
        {
            await SetTestimonialVisibilityOnHome(id, false);
        }
    }
}