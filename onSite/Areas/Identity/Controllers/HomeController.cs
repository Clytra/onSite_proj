using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace onSite.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));

        [Authorize(Roles = "Users")]
        public IActionResult OtherAction() => View("Index",
            GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Akcja"] = actionName,
                ["Użytkownik"] = HttpContext.User.Identity.Name,
                ["Uwierzytelniony?"] = HttpContext.User.Identity.IsAuthenticated,
                ["Typ uwierzytelnienia"] = HttpContext.User.Identity.AuthenticationType,
                ["Przypisany do roli Użytkownicy?"] = HttpContext.User.IsInRole("Users")
            };
    }
}