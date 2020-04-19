using Microsoft.AspNetCore.Mvc;
using onSite.Areas.Topo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ITopoRepository repository;

        public NavigationMenuViewComponent(ITopoRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(repository.Topos
                .Select(x => x.Area)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
