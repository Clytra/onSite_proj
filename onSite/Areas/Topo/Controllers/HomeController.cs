using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class HomeController : Controller
    {
        private ITopoRepository repository;

        public HomeController(ITopoRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Topos);
    }
}