using Microsoft.AspNetCore.Mvc;
using Moq;
using onSite.Areas.Topo.Controllers;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Components;
using onSite.Repository;
using System;
using System.Linq;
using Xunit;

namespace onSite.Tests
{
    public class TopoControllerTests
    {
        [Fact]
        public void Generate_Type_Specific_Area_Count()
        {
            //Przygotowanie
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns((new TopoModel[]
            {
                new TopoModel {TopoID = 1, Area = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Ska³a1", Wall = "Œciana1"},
                new TopoModel {TopoID = 2, Area = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Ska³a2", Wall = "Œciana2"},
                new TopoModel {TopoID = 3, Area = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Ska³a3", Wall = "Œciana3"},
                new TopoModel {TopoID = 4, Area = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Ska³a4", Wall = "Œciana4"},
                new TopoModel {TopoID = 5, Area = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Ska³a5", Wall = "Œciana5"},
                new TopoModel {TopoID = 6, Area = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Ska³a6", Wall = "Œciana6"},
                new TopoModel {TopoID = 7, Area = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Ska³a7", Wall = "Œciana7"},
            }).AsQueryable<TopoModel>());

            TopoController target = new TopoController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, TopoListViewModel> GetModel = result =>
            result?.ViewData?.Model as TopoListViewModel;

            //Dzia³anie
            int? res1 = GetModel(target.List("Obszar1"))?.PagingInfo.TotalRecords;
            int? res2 = GetModel(target.List("Obszar2"))?.PagingInfo.TotalRecords;
            int? res3 = GetModel(target.List("Obszar3"))?.PagingInfo.TotalRecords;
            int? res4 = GetModel(target.List("Obszar4"))?.PagingInfo.TotalRecords;
            int? res5 = GetModel(target.List("Obszar5"))?.PagingInfo.TotalRecords;
            int? res6 = GetModel(target.List("Obszar6"))?.PagingInfo.TotalRecords;
            int? res7 = GetModel(target.List("Obszar7"))?.PagingInfo.TotalRecords;
            int? resAll = GetModel(target.List(null))?.PagingInfo.TotalRecords;

            //Asercje
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Przygotowanie
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns((new TopoModel[]
            {
                new TopoModel {TopoID = 1, Area = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Ska³a1", Wall = "Œciana1"},
                new TopoModel {TopoID = 2, Area = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Ska³a2", Wall = "Œciana2"},
                new TopoModel {TopoID = 3, Area = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Ska³a3", Wall = "Œciana3"},
                new TopoModel {TopoID = 4, Area = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Ska³a4", Wall = "Œciana4"},
                new TopoModel {TopoID = 5, Area = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Ska³a5", Wall = "Œciana5"},
                new TopoModel {TopoID = 6, Area = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Ska³a6", Wall = "Œciana6"},
                new TopoModel {TopoID = 7, Area = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Ska³a7", Wall = "Œciana7"},
            }).AsQueryable<TopoModel>());

            //Przygotowanie
            TopoController controller =
                new TopoController(mock.Object) { PageSize = 3 };

            //Dzia³anie
            TopoListViewModel result =
                controller.List(null, 2).ViewData.Model as TopoListViewModel;

            //Asercje
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.RecordsPerPage);
            Assert.Equal(5, pageInfo.TotalRecords);
            Assert.Equal(2, pageInfo.TotalPages);
        }


        [Fact]
        public void Can_Paginate()
        {
            //Przygotowanie
            Mock<ITopoRepository> mock = new Mock<ITopoRepository>();
            mock.Setup(m => m.Topos).Returns((new TopoModel[]
            {
                new TopoModel {TopoID = 1, Area = "Obszar1", Region = "Region1", Sector = "Sektor1", Rock = "Ska³a1", Wall = "Œciana1"},
                new TopoModel {TopoID = 2, Area = "Obszar2", Region = "Region2", Sector = "Sektor2", Rock = "Ska³a2", Wall = "Œciana2"},
                new TopoModel {TopoID = 3, Area = "Obszar3", Region = "Region3", Sector = "Sektor3", Rock = "Ska³a3", Wall = "Œciana3"},
                new TopoModel {TopoID = 4, Area = "Obszar4", Region = "Region4", Sector = "Sektor4", Rock = "Ska³a4", Wall = "Œciana4"},
                new TopoModel {TopoID = 5, Area = "Obszar5", Region = "Region5", Sector = "Sektor5", Rock = "Ska³a5", Wall = "Œciana5"},
                new TopoModel {TopoID = 6, Area = "Obszar6", Region = "Region6", Sector = "Sektor6", Rock = "Ska³a6", Wall = "Œciana6"},
                new TopoModel {TopoID = 7, Area = "Obszar7", Region = "Region7", Sector = "Sektor7", Rock = "Ska³a7", Wall = "Œciana7"},
            }).AsQueryable<TopoModel>());

            TopoController controller = new TopoController(mock.Object);
            controller.PageSize = 3;

            //Dzia³anie
            TopoListViewModel result = controller.List(null, 2).ViewData.Model as TopoListViewModel;

            //Asercje
            TopoModel[] topoArray = result.Topos.ToArray();
            Assert.True(topoArray.Length == 2);
            Assert.Equal("Obszar4", topoArray[0].Area);
            Assert.Equal("Obszar5", topoArray[1].Area);
        }
    }
}
