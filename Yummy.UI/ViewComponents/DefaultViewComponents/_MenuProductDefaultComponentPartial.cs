using Microsoft.AspNetCore.Mvc;
using Yummy.UI.DTOs.ProductDTOs;
using Yummy.UI.Helpers;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _MenuProductDefaultComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDTO>>("Products/visible-on-home");
            return View(values);
        }
    }
}