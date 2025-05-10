using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialManager(IRepository<Testimonial> _repository, ITestimonialRepository testimonialRepository) : base(_repository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task TSetTestimonialHiddenOnHome(int id)
        {
            await _testimonialRepository.SetTestimonialHiddenOnHome(id);
        }

        public async Task TSetTestimonialVisibleOnHome(int id)
        {
            await _testimonialRepository.SetTestimonialVisibleOnHome(id);
        }

        public async Task TToggleTestimonialStatus(int id)
        {
            await _testimonialRepository.ToggleTestimonialStatus(id);
        }
    }
}