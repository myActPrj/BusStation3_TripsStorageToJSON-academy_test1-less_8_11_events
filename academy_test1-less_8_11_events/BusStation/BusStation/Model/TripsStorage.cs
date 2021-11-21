using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace BusStation.Model
{
    public class TripsStorage
    {
        //public static List<TripModel> Trips = new List<TripModel>
        //{ 
        //    new TripModel(1, new DateTime(2022,1,1), "Jmerynka", new DateTime(2022,1,2), "Paris", new BusModel("Ikarus", 35), 1500),
        //    new TripModel(2, new DateTime(2022,1,6), "Kyiv", new DateTime(2022,1,7), "Bukovel", new BusModel("Bohdan", 20), 500),
        //    new TripModel(3, new DateTime(2022,1,13), "Kurvamat", new DateTime(2022,1,15), "Ternopil", new BusModel("Sprinter", 18), 1200)
        //};

        public List<TripModel> Trips
        {
            get
            {
                LoadTrips();
                return _trips;
            }
        }
        private List<TripModel> _trips = new List<TripModel>();

        private string _tripsFFileName = @"..\..\..\Model\Trips.json";
        private static TripsStorage _instance;
        public bool LoadTrips()
        {
            _trips.Clear();
            if (loadTripsFile(_tripsFFileName, out string tripsJSON))
            {
                try
                {
                    _trips = JsonConvert.DeserializeObject<List<TripModel>>(tripsJSON);
                    return true;
                }
                catch
                {
                    printErrorFileInfo("Помилка при парсингу json-файла ", _tripsFFileName);
                }
            }
            return false;
        }
        private bool loadTripsFile(string tripsFileName, out string trips)
        {
            trips = "";
            if (new FileInfo(tripsFileName).Exists)
            {
                try
                {
                    using (StreamReader fstream = new StreamReader(tripsFileName))
                    {
                        trips = fstream.ReadToEnd();
                        return true;
                    }
                }
                catch
                {
                    printErrorFileInfo($"Помилка відкриття json-файла на читання: ", tripsFileName);
                    return false;
                }
            }
            else
            {
                printErrorFileInfo($"json-файл маршрутів не знайдено: ", tripsFileName);
                return false;
            }
        }

        public bool SaveTrips()
        {
            return saveTripsFile(_tripsFFileName);
        }
        private bool saveTripsFile(string tripsFileName)
        {
            string tripsJSON = JsonConvert.SerializeObject(_trips);
            try
            {
                using (StreamWriter fstream = new StreamWriter(tripsFileName))
                {
                    fstream.Write(tripsJSON);
                    return true;
                }
            }
            catch
            {
                printErrorFileInfo($"Помилка запису маршрутів в json-файл: ", tripsFileName);
                return false;
            }
        }

        //----------------------------------
        //ф-ї виведенння помилок виконнання/роботи з файлами
        //----------------------------------
        private void printError(string mesage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mesage);
            Console.ResetColor();
        }
        private void printErrorFileInfo(string mesage, string fileName)
        {
            string fullFileName = Path.GetFullPath(fileName);
            printError(mesage + fullFileName);
        }
        //----------------------------------

        public bool DeleteTripById(int id)
        {
            bool _deleteDone = false;

            for (int i = 0; i <= _trips.Count-1; i++)
            {
                if(_trips[i].Id==id)
                {
                    _trips.RemoveAt(i);
                    _deleteDone = true;
                    break;
                }
            }

            if (_deleteDone)
            {
                if (SaveTrips()==false)
                {
                    LoadTrips();
                    return false;
                }
            }

            return _deleteDone;
        }
        private TripsStorage()
        {
            LoadTrips();
        }
        public static TripsStorage GetInstance()
        {
            if(_instance == null)
            {
                _instance = new TripsStorage();
            }
            return _instance;
        }

    }
}
