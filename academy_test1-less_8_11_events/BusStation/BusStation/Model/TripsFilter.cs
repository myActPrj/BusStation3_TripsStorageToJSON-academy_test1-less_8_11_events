using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Model
{
    class TripsFilter
    {
        public static List<TripModel> GetTripsById(List<TripModel> trips, int id)
        {
            List<TripModel> tripsById = trips.Where(trip => trip.Id == id).ToList();
            return tripsById;
        }

        public static List<TripModel> GetTripsByTripTo(List<TripModel> trips, string tripTo)
        {
            List<TripModel> tripsById = trips.Where(trip => trip.TripTo.ToLower() == tripTo.ToLower()).ToList();
            return tripsById;
        }

        public static List<TripModel> GetTripsByDepartureTime(List<TripModel> trips, DateTime beginDate, DateTime endDate)
        {
            List<TripModel> tripsByDepartureTime = trips.Where(trip => ((trip.DepartureTime >= beginDate) && (trip.DepartureTime < endDate))).ToList();
            return tripsByDepartureTime;
        }

        public static List<TripModel> GetTripByTicketPriceLess(List<TripModel> trips, float ticketPrice)
        {
            List<TripModel> tripsByDepartureTime = trips.Where(trip => trip.TicketPrice < ticketPrice ).ToList();
            return tripsByDepartureTime;
        }

        public static List<TripModel> GetTripByBusCapacityTheMore(List<TripModel> trips, int busCapacityMore)
        {
            List<TripModel> tripsByBusCapacityIsMore = trips.Where(trip => trip.Bus.Capacity > busCapacityMore).ToList();
            return tripsByBusCapacityIsMore;
        }
    }
}
