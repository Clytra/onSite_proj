using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;

namespace onSite.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private ITopoRepository _repository;

        public AdminController(ITopoRepository repo)
        {
            _repository = repo;
        }

        public ViewResult TopoList()
            => View(_repository.Topos);

        public ViewResult RouteList()
            => View(_repository.Topos);
    }
}