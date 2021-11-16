using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Model
{
    class TripsFilter
    {
        // фильтрация по Id
        public static List<TripModel> GetTripsById(List<TripModel> trips, int id)
        {
            List<TripModel> tripsById = trips.Where(trip => trip.Id == id).ToList();
            return tripsById;
        }

        // фильтрация по TripTo
        public static List<TripModel> GetTripsByTripTo(List<TripModel> trips, string tripTo)
        {
            List<TripModel> tripsById = trips.Where(trip => trip.TripTo.ToLower() == tripTo.ToLower()).ToList();
            return tripsById;
        }

        // фильтрация по DepartureTime
        public static List<TripModel> GetTripsByDepartureTime(List<TripModel> trips, DateTime beginDate, DateTime endDate)
        {
            // чомусь LINQ - видаэ помилку:
            List<TripModel> tripsByDepartureTime_WhyERROR = trips.Where(trip => ((trip.DepartureTime >= beginDate) && (trip.DepartureTime < endDate)));

            //List<TripModel> tripsByDepartureTime = new List<TripModel>();
            //foreach (var trip in trips)
            //{
            //    if ((trip.DepartureTime >= beginDate) && (trip.DepartureTime <= endDate))
            //    {
            //        tripsByDepartureTime.Add(trip);
            //    }
            //}

            return tripsByDepartureTime;
        }
    }
}
