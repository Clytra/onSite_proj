using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Authorize]
    public class AdminController : Controller
    {
        private ITopoRepository _repository;
        private UserManager<IdentityUser> _userManager;
        private IUserValidator<IdentityUser> _userValidator;
        private IPasswordValidator<IdentityUser> _passwordValidator;
        private IPasswordHasher<IdentityUser> _passwordHasher;

        public AdminController(ITopoRepository repo,
            UserManager<IdentityUser> usrMgr,
            IUserValidator<IdentityUser> userValid,
            IPasswordValidator<IdentityUser> passValid,
            IPasswordHasher<IdentityUser> passHash)
        {
            _repository = repo;
            _userManager = usrMgr;
            _userValidator = userValid;
            _passwordValidator = passValid;
            _passwordHasher = passHash;
        }

        public ViewResult Index() => View(_userManager.Users);

        public ViewResult TopoList()
            => View(new TopoListViewModel
            {
                Topos = _repository.Topos
            });

        public ViewResult Edit(int topoId)
            => View(_repository.Topos
                .FirstOrDefault(t => t.TopoID == topoId));

        [HttpPost]
        public IActionResult Edit(TopoModel topoModel)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveTopo(topoModel);
                TempData["message"] = "Dane zapisano pomyślnie";
                return RedirectToAction("TopoList");
            }
            else
            {
                //Błąd w wartościach danych
                return View(topoModel);
            }
        }

        public ViewResult Create() =>
            View("Edit", new TopoModel());

        [HttpPost]
        public IActionResult Delete(int topoId)
        {
            TopoModel deletedTopo = _repository.DeleteTopo(topoId);
            if(deletedTopo != null)
            {
                TempData["message"] = $"Usunięto {deletedTopo.TopoID}.";
            }
            return RedirectToAction("TopoList");
        }

        public async Task<IActionResult> EditUser(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> EditUser(string id, string email, string password)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                    = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                    || (validEmail.Succeeded
                    && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
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
                ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            }
            return View("Index", _userManager.Users);
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