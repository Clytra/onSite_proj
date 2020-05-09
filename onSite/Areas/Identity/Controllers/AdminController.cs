using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Identity.Models;
using onSite.Areas.Identity.Models.ViewModels;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Areas.Admin.Controllers
{
    [Area("Identity")]
    [Authorize]
    public class AdminController : Controller
    {
        private ITopoRepository _repository;
        private UserManager<AppUserModel> _userManager;

        public AdminController(ITopoRepository repo,
            UserManager<AppUserModel> userMgr)
        {
            _repository = repo;
            _userManager = userMgr;
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
    }
}