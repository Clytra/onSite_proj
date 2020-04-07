using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using onSite.Infrastructure;

namespace onSite.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;

        public HomeController(UptimeService up) => _uptime = up;

        public ViewResult Index(bool throwException = false)
        {
            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Uptime"] = $"{_uptime.Uptime}ms"
            });
        }

        public ViewResult Error() => View(nameof(Index),
            new Dictionary<string, string>
            {
                ["Message"] = "metoda akcji o nazwie Error()"
            });
    }
}