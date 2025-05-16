using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.ChefDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _ChefDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultChefDTO>>("Chefs/last-three-active");
            return View(values);
        }
    }
}