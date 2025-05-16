using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.ViewComponents.DefaultViewComponents
{
    public class _ScriptDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}