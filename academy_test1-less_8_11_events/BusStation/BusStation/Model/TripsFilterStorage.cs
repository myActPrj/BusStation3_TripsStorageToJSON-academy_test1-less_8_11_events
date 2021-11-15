using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Model
{
    class TripsFilterStorage
    {
        //----------------------------------
        // GetById фильтрация по Id
        //----------------------------------
        public static List<TripModel> GetTripsById(List<TripModel> trips, int id)
        {
            List<TripModel> tripsById = trips.Where(trip => trip.Id == id).ToList();
            return tripsById;
        }
        //----------------------------------

    }
}
