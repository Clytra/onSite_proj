using onSite.Areas.Topo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Infrastructure
{
    public static class Filters
    {
        public static IEnumerable<ClimbingRouteModel> FilterByDifficulty(
            this IEnumerable<ClimbingRouteModel> difficultyEnum, char firstLetter)
        {
            foreach (ClimbingRouteModel routeModel in difficultyEnum)
            {
                if (routeModel?.Difficulty?[0] == firstLetter)
                {
                    yield return routeModel;
                }
            }
        }

        public static IEnumerable<TopoModel> FilterByName(
            this IEnumerable<TopoModel> wallEnum, char firstLetter)
        {
            foreach (TopoModel topoModel in wallEnum)
            {
                if (topoModel?.Wall?[0] == firstLetter)
                {
                    yield return topoModel;
                }
            }
        }
    }
}
