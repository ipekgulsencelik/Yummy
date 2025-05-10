using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        Task TSetTestimonialVisibleOnHome(int id);
        Task TSetTestimonialHiddenOnHome(int id);
        Task TToggleTestimonialStatus(int id);
    }
}