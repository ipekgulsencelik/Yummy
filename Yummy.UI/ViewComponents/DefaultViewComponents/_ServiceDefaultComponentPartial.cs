using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}