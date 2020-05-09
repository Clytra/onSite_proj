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
            ViewBag.SelectedTerritory = RouteData?.Values["territory"];
            return View(repository.Topos
                .Select(x => x.Territory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
