using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Repository.Topo;
using System.Linq;

namespace onSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private ITopoRepository _topoRepository;
        private IRouteRepository _routeRepository;

        public AdminController(ITopoRepository tRepo, IRouteRepository rRepo)
        {
            _topoRepository = tRepo;
            _routeRepository = rRepo;
        }

        public ViewResult TopoList()
            => View(new TopoListViewModel
            {
                Topos = _topoRepository.Topos
            });

        public ViewResult Edit(int routeId)
            => View(_routeRepository.Routes
                .FirstOrDefault(t => t.RouteID == routeId));
    }
}