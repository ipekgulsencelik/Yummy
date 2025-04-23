using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.CategoryDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _MenuCategoryDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories/visible-on-home");
            return View(values);
        }
    }
}