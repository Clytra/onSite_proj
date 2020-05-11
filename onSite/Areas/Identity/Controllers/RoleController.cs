using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Identity.Models.ViewModels;

namespace onSite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Identity")]
    public class RoleController : Controller
    {
        protected RoleManager<IdentityRole> _roleManager { get; }
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            _roleManager = _roleManager;
        }
        public ViewResult Index() => View(_roleManager.Roles);

        public IActionResult Add() => View();
        public async Task<IActionResult> Add(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ir = new IdentityRole(viewModel.Name);
                var result = await _roleManager.CreateAsync(ir);
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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Nie znaleziono roli.");
            }
            return View("Index", _roleManager.Roles);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}