using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using onSite.Infrastructure;

namespace onSite.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;

        public HomeController(UptimeService up) => _uptime = up;

        public ViewResult Index()
            => View(new Dictionary<string, string>
            {
                ["Uptime"] = $"{_uptime.Uptime}ms"
            });
    }
}