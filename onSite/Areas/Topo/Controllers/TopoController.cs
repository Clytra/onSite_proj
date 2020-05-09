using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Components;
using onSite.Repository;
using System.Linq;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class TopoController : Controller
    {
        private ITopoRepository _repository;
        public int PageSize = 5;

        public TopoController(ITopoRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List(string region, int topoPage = 1)
            => View(new TopoListViewModel
            {
                Topos = _repository.Topos
                .Where(p => region == null || p.Region == region)
                .OrderBy(p => p.TopoID)
                .Skip((topoPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = topoPage,
                    RecordsPerPage = PageSize,
                    TotalRecords = region == null ?
                        _repository.Topos.Count() :
                        _repository.Topos.Where(e =>
                        e.Region == region).Count()
                },
                CurrentRegion = region
            });
    }
}