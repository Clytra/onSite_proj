using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using System.Linq;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class HomeController : Controller
    {
        private ITopoRepository repository;
        public int PageSize = 5;

        public HomeController(ITopoRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string type, int topoPage = 1)
            => View(new TopoListViewModel
            {
                Topos = repository.Topos
                .Where(p => type == null || p.Area == type)
                .OrderBy(p => p.TopoID)
                .Skip((topoPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = topoPage,
                    RecordsPerPage = PageSize,
                    TotalRecords = repository.Topos.Count()
                },
                CurrentType = type
            });
    }
}