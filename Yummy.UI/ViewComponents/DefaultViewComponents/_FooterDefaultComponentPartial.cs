using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _FooterDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}