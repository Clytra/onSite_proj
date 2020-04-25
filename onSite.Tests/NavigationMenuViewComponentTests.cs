using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using onSite.Areas.Topo.Models;
using onSite.Components;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace onSite.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Areas()
        {
            //Przygotowanie
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns((new TopoModel[]
            {
                new TopoModel {TopoID = 1, Voivodeship = "Województwo1", Area = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Voivodeship = "Województwo2", Area = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Voivodeship = "Województwo3", Area = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Voivodeship = "Województwo4", Area = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Voivodeship = "Województwo5", Area = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Voivodeship = "Województwo6", Area = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Voivodeship = "Województwo7", Area = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Skała7", Wall = "Ściana7"},
            }).AsQueryable<TopoModel>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);

            //Działanie - pobieranie zbioru obszarów
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();

            //Asercje
            Assert.True(Enumerable.SequenceEqual(new string[] { "Obszar1", "Obszar2", "Obszar3", "Obszar4", "Obszar5",
                "Obszar6", "Obszar7" }, results));
        }

        [Fact]
        public void Indicates_Selected_Area()
        {
            //Przygotowanie
            string areaToSelect = "Obszar2";
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns((new TopoModel[]
            {
                new TopoModel {TopoID = 1, Voivodeship = "Województwo1", Area = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Voivodeship = "Województwo2", Area = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Voivodeship = "Województwo3", Area = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Voivodeship = "Województwo4", Area = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Voivodeship = "Województwo5", Area = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Voivodeship = "Województwo6", Area = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Voivodeship = "Województwo7", Area = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Skała7", Wall = "Ściana7"},
            }).AsQueryable<TopoModel>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };

            target.RouteData.Values["type"] = areaToSelect;

            //Działanie
            string result = (string)(target.Invoke() as
                ViewViewComponentResult).ViewData["SelectedType"];

            //Asercje
            Assert.Equal(areaToSelect, result);
        }
    }
}
