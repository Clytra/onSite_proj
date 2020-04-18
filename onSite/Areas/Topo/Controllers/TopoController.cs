using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using System.Linq;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class TopoController : Controller
    {
        private ITopoRepository repository;
        public int PageSize = 5;

        public TopoController(ITopoRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int topoPage = 1)
            => View(new TopoListViewModel
            {
                Topos = repository.Topos
                .OrderBy(p => p.TopoID)
                .Skip((topoPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = topoPage,
                    RecordsPerPage = PageSize,
                    TotalRecords = repository.Topos.Count()
                }
            });

        public ViewResult List() => View(repository.Topos);
    }
}