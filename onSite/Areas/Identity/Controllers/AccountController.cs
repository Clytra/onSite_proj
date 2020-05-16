using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using onSite.Areas.Identity.Models.ViewModels;

namespace onSite.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        public AccountController(SignInManager<IdentityUser> _signInManager,
            UserManager<IdentityUser> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(viewModel.Login) { Email = viewModel.Email };
                var result = await userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    var login = await signInManager.PasswordSignInAsync(viewModel.Login,
                viewModel.Password, true, false);
                    if (login.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nie można się zalogować!");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel viewModel)
        {
            //TODO: Po dodaniu obsługi ról, uzupełnienie poniższej logiki o warunek:
            // jeśli użytkownik == Admin - do AdminLayout
            // pozostali do defaultowej ścieżki
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(viewModel.Login,
                viewModel.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Nie można się zalogować!");
                }
            }
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult ExternalLogin(string provider, string returnUrl)
            //{
            //    //return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
            //}

            //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
            //{
            //    //var loginInfo = await AuthenticationManager.GetExternalInfoAsync();
            //    //if(loginInfo == null)
            //    //{
            //    //    return RedirectToAction("Login");
            //    //}

            //    //var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            //    //switch (result)
            //    //{
            //    //    case SignInStatus.Succ
            //    //}
            //}
        }
    }
}