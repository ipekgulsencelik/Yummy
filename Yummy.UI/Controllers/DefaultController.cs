using Microsoft.AspNetCore.Mvc;

namespace Yummy.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
