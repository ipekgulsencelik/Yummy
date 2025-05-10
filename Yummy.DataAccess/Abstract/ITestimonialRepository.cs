using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface ITestimonialRepository : IRepository<Testimonial>
    {
        Task SetTestimonialVisibleOnHome(int id);
        Task SetTestimonialHiddenOnHome(int id);
        Task ToggleTestimonialStatus(int id);
    }
}