using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;

namespace onSite.Areas.Topo.Controllers
{
    public class TopoController : Controller
    {
        private ITopoRepository repository;

        public TopoController(ITopoRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Topos);
    }
}