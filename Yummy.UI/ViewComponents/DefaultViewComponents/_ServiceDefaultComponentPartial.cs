using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.ServiceDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultServiceDTO>>("Services/last-three-active");
            return View(values);
        }
    }
}