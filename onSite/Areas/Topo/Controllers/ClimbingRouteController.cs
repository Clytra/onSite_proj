using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using onSite.Areas.Topo.Models;
using onSite.Repository;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class ClimbingRouteController : Controller
    {
        private ITopoRepository _repository;

        public ClimbingRouteController(ITopoRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Create()
        {
            var topos = _repository.Topos.ToList();
            var climb = new ClimbingRouteModel
            {
                Regions = (from r in topos
                           select new SelectListItem
                           {
                               Text = r.Region,
                               Value = r.TopoID.ToString(),
                               Selected = false
                           }),

                Areas = (from a in topos
                         select new SelectListItem
                         {
                             Text = a.Territory,
                             Value = a.TopoID.ToString(),
                             Selected = false
                         }),

                Rocks = (from rock in topos
                         select new SelectListItem
                         {
                             Text = rock.Rock,
                             Value = rock.TopoID.ToString(),
                             Selected = false
                         }),

                Walls = (from w in topos
                         select new SelectListItem
                         {
                             Text = w.Wall,
                             Value = w.TopoID.ToString(),
                             Selected = false
                         }),
            };
            return View("Create", climb);
        }

        public ViewResult Edit(int routeId) =>
            View(_repository.Routes
                .FirstOrDefault(t => t.RouteID == routeId));

        [HttpPost]
        public IActionResult Edit(ClimbingRouteModel climbing)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveTopo(climbing);
                TempData["message"] = $"Dodano drogę wspinaczkową do bazy";
                return RedirectToAction("List", "Topo");
            }
            else
            {
                //Błąd w wartościach danych
                return View(climbing);
            }
        }

        [HttpPost]
        public IActionResult Delete(int routeId)
        {
            ClimbingRouteModel deletedTopo = _repository.DeleteTopo(routeId);
            if (deletedTopo != null)
            {
                TempData["message"] = $"Usunięto wybrany rekord z bazy";
            }
            return RedirectToAction("List", "Topo");
        }
    }
}