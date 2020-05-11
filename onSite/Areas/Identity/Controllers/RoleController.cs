using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization.Internal;
using onSite.Areas.Identity.Models.ViewModels;

namespace onSite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Identity")]
    public class RoleController : Controller
    {
        protected RoleManager<IdentityRole> _roleManager { get; }
        private UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> _roleManager,
            UserManager<IdentityUser> userMgr)
        {
            _roleManager = _roleManager;
            _userManager = userMgr;
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

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();
            foreach (IdentityUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                    ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user,
                            model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user,
                            model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Edit(model.RoleId);
            }
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