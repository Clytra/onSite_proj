using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization.Internal;
using onSite.Areas.Identity.Models.ViewModels;

namespace onSite.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Authorize]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        protected RoleManager<IdentityRole> roleManager { get; }
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public async Task<IActionResult> Add(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ir = new IdentityRole(viewModel.Name);
                var result = await roleManager.CreateAsync(ir);
                if (result.Succeeded)
                {

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }
    }
}