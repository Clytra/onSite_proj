using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using onSite.Areas.Identity.Controllers;
using onSite.Areas.Topo.Models;
using onSite.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace onSite.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void TopoList_Contains_All_Topo()
        {
            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns(new TopoModel[] {
                new TopoModel {TopoID = 1, Territory = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Territory = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Territory = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Territory = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Territory = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Territory = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Territory = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Skała7", Wall = "Ściana7"},
            }.AsQueryable<TopoModel>());

            //Przygotowanie - utworzenie kontrolera
            AdminController target = new AdminController(mock.Object);

            //Działanie
            TopoModel[] result =
                GetViewModel<IEnumerable<TopoModel>>(target.TopoList())?.ToArray();

            //Asercje
            Assert.Equal(3, result.Length);
            Assert.Equal("Obszar1", result[0].Territory);
            Assert.Equal("Obszar2", result[1].Territory);
            Assert.Equal("Obszar3", result[2].Territory);
            Assert.Equal("Obszar4", result[3].Territory);
            Assert.Equal("Obszar5", result[4].Territory);
            Assert.Equal("Obszar6", result[5].Territory);
            Assert.Equal("Obszar7", result[6].Territory);
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Record()
        {
            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns(new TopoModel[] {
                new TopoModel {TopoID = 1, Territory = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Territory = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Territory = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Territory = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Territory = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Territory = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Territory = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Skała7", Wall = "Ściana7"},
                }.AsQueryable<TopoModel>());

            //Przygotowanie - utworzenie kontrolera
            AdminController target = new AdminController(mock.Object);

            //Działanie
            TopoModel t1 = GetViewModel<TopoModel>(target.Edit(1));
            TopoModel t2 = GetViewModel<TopoModel>(target.Edit(2));
            TopoModel t3 = GetViewModel<TopoModel>(target.Edit(3));
            TopoModel t4 = GetViewModel<TopoModel>(target.Edit(4));
            TopoModel t5 = GetViewModel<TopoModel>(target.Edit(5));
            TopoModel t6 = GetViewModel<TopoModel>(target.Edit(6));
            TopoModel t7 = GetViewModel<TopoModel>(target.Edit(7));

            //Asercje
            Assert.Equal(1, t1.TopoID);
            Assert.Equal(2, t2.TopoID);
            Assert.Equal(3, t3.TopoID);
            Assert.Equal(4, t4.TopoID);
            Assert.Equal(5, t5.TopoID);
            Assert.Equal(6, t6.TopoID);
            Assert.Equal(7, t7.TopoID);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Record()
        {
            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns(new TopoModel[]
            {
                new TopoModel {TopoID = 1, Territory = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Skała1", Wall = "Ściana1"},
                new TopoModel {TopoID = 2, Territory = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Territory = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
                new TopoModel {TopoID = 4, Territory = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Skała4", Wall = "Ściana4"},
                new TopoModel {TopoID = 5, Territory = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Skała5", Wall = "Ściana5"},
                new TopoModel {TopoID = 6, Territory = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Skała6", Wall = "Ściana6"},
                new TopoModel {TopoID = 7, Territory = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Skała7", Wall = "Ściana7"},
            }.AsQueryable<TopoModel>());

            //Przygotowanie - utworzenie repozytorium
            AdminController target = new AdminController(mock.Object);

            //Działanie
            TopoModel result = GetViewModel<TopoModel>(target.Edit(8));

            //Asercje
            Assert.Null(result);
        }

        [Fact]
        public void Can_Delete_Valid_Records()
        {
            //Przygotowanie - tworzenie rekordu
            TopoModel topoModel = new TopoModel
            {
                TopoID = 1,
                Territory = "Obszar1",
                Region = "Region1",
                Sector = "Sektor1",
                Rock = "Skała1",
                Wall = "Ściana1"
            };

            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns(new TopoModel[]
            {
                topoModel,
                new TopoModel {TopoID = 2, Territory = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Skała2", Wall = "Ściana2"},
                new TopoModel {TopoID = 3, Territory = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Skała3", Wall = "Ściana3"},
            }.AsQueryable<TopoModel>());

            //Przygotowanie - tworzenie kontrolera
            AdminController target = new AdminController(mock.Object);

            //Działanie - usunięcie rekordu
            target.Delete(topoModel.TopoID);

            //Asercje - upewnienie się, że metoda repozytorium
            //została wywołana z właściwym rekordem
            mock.Verify(m => m.DeleteTopo(topoModel.TopoID));
        }

        [Fact]
        public void Can_Save_Valid_changes()
        {
            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();

            //Przygotowanie - tworzenie imitacji kontenera TempData
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();

            //Przygotowanie - tworzenie kontrolera
            AdminController target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };

            //Przygotowanie - tworzenie obiektu
            TopoModel topoModel = new TopoModel { Territory = "Obszar1" };

            //Działanie - prośba zapisania rekordu
            IActionResult result = target.Edit(topoModel);

            //Asercje - sprawdzanie, czy zostało wywołane repozytorium
            mock.Verify(m => m.SaveTopo(topoModel));

            //Asercje - sprawdzanie typu zwracanego z metody
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("TopoList", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            //Przygotowanie - tworzenie imitacji repozytorium
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();

            //Przygotowanie - tworzenie kontrolera
            AdminController target = new AdminController(mock.Object);

            //Przygotowanie - tworzenie obiektu
            TopoModel topoModel = new TopoModel { Territory = "Obszar1" };

            //Przygotowanie - dodanie błędu do stanu modelu
            target.ModelState.AddModelError("error", "error");

            //Działanie - próba zapisania obiektu
            IActionResult result = target.Edit(topoModel);

            //Asercje - sprawdzanie, czy nie zostało wywołane repozytorium
            mock.Verify(m => m.SaveTopo(It.IsAny<TopoModel>()), Times.Never());

            //Asercje - sprawdzenie typu zwracanego z metody
            Assert.IsType<ViewResult>(result);
        }
    }
}
