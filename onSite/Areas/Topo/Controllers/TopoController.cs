using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onSite.Areas.Topo.Models;
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

        public ViewResult List(string territory, int topoPage = 1)
            => View(new TopoListViewModel
            {
                Topos = _repository.Topos
                .Where(t => territory == null || t.Territory == territory)
                .OrderBy(t => t.TopoID)
                .Skip((topoPage - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = topoPage,
                    RecordsPerPage = PageSize,
                    TotalRecords = territory == null ?
                        _repository.Topos.Count() :
                        _repository.Topos.Where(e =>
                        e.Territory == territory).Count()
                },

                //regions = _repository.Topos
                //.Where(r => territory == null || r.Territory == territory)
                //.Select(r => r.Region).Distinct().ToList(),

                //rocks = _repository.Topos
                //.Where(ro => territory == null || ro.Territory == territory)
                //.Select(ro => ro.Rock).Distinct().ToList(),

                //walls = _repository.Topos
                //.Where(w => territory == null || w.Territory == territory)
                //.Select(w => w.Wall).Distinct().ToList(),

                CurrentTerritory = territory
            });

        
    }
}