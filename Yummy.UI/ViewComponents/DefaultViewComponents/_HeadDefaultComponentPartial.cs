using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}