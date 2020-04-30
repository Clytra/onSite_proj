using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Repository.Topo;

namespace onSite.Areas.Topo.Controllers
{
    [Area("Topo")]
    public class RouteController : Controller
    {
        private IRouteRepository _repository;

        public RouteController(IRouteRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Routes(int topoId) 
            => View(new RoutesListViewModel 
        {
        });
    }
}