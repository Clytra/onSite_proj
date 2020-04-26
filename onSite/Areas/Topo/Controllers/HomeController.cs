using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Components;
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

        public ViewResult List(string region, int topoPage = 1)
            => View(new TopoListViewModel
            {
                Topos = repository.Topos
                .Where(p => region == null || p.Region == region)
                .OrderBy(p => p.TopoID)
                .Skip((topoPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = topoPage,
                    RecordsPerPage = PageSize,
                    TotalRecords = region == null ?
                        repository.Topos.Count() :
                        repository.Topos.Where(e =>
                        e.Region == region).Count()
                },
                CurrentRegion = region
            });
    }
}