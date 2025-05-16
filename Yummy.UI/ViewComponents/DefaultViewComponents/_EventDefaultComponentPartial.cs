using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.EventDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _EventDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultEventDTO>>("YummyEvents/last-five-active");
            return View(values);
        }
    }
}