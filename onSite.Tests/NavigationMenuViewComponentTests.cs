using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using onSite.Areas.Topo.Models;
using onSite.Components;
using onSite.Repository;
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
                new TopoModel {TopoID = 1, Territory = "Obszar1", Region = "Region1",  Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Territory = "Obszar2", Region = "Region2",  Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Territory = "Obszar3", Region = "Region3",  Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Territory = "Obszar4", Region = "Region4",  Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Territory = "Obszar5", Region = "Region5",  Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Territory = "Obszar6", Region = "Region6",  Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Territory = "Obszar7", Region = "Region7",  Rock = "Skała7", Wall = "Ściana7"},
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
    }
}
