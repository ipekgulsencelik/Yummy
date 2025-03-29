using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}