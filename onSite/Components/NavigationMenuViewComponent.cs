using Microsoft.AspNetCore.Mvc;
using onSite.Repository;
using System.Collections.Generic;
using System.Linq;

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
            ViewBag.SelectedRegion = RouteData?.Values["region"];
            return View(repository.Topos
                .Select(x => x.Region)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
