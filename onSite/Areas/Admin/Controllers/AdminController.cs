using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Repository;
using System.Linq;

namespace onSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private ITopoRepository _repository;

        public AdminController(ITopoRepository repo)
        {
            _repository = repo;
        }

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