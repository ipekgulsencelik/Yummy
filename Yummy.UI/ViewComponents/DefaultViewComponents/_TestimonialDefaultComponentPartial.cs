using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.TestimonialDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _TestimonialDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonials/last-four-active");
            return View(values);
        }
    }
}