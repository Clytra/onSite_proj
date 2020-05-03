using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using System.Linq;

namespace onSite.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}