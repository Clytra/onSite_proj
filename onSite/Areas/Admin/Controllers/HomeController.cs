using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;

namespace onSite.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ITopoRepository repository;

        public HomeController(ITopoRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Topos);
    }
}