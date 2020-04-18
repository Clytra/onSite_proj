using onSite.Areas.Topo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Repository
{
    public class FakeTopoRepository : ITopoRepository
    {
        public IQueryable<TopoModel> Topos => new List<TopoModel>
        {
            new TopoModel { TopoID = 1 ,Voivodeship = "Świętokrzyskie", Area = "Stokówka", Rock = "Kalcytowa Ściana", ClimbingRoute = "Święta brzózka", Difficulty = "VI.1"},
            new TopoModel { TopoID = 1 ,Voivodeship = "Świętokrzyskie", Area = "Stokówka", Rock = "Wpizdu Korner", ClimbingRoute = "Bułka z masłem", Difficulty = "VI+"},
            new TopoModel { TopoID = 1 ,Voivodeship = "Małopolskie", Area = "Będkowska", Rock = "Misiaczek", ClimbingRoute = "Trzeci Miś", Difficulty = "III+"},
            new TopoModel { TopoID = 1 ,Voivodeship = "Śląskie", Area = "Mirów", Rock = "Mniszek", ClimbingRoute = "Ściany Mają Uszy", Difficulty = "VI"},
            new TopoModel { TopoID = 1 ,Voivodeship = "Małopolskie", Area = "Ciężkowice", Rock = "Flakon", ClimbingRoute = "Półprodukt", Difficulty = "VI.3"},
            new TopoModel { TopoID = 1 ,Voivodeship = "Dolnośląskie", Area = "Sokoliki", Rock = "Sukiennice", ClimbingRoute = "Kuj Haczora", Difficulty = "VI"}
        }.AsQueryable<TopoModel>();
    }
}
