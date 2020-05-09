using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace onSite.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}