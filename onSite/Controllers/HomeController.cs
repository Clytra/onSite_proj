using Microsoft.AspNetCore.Mvc;

namespace onSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}