using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkingGrandLyon
{
    public class Parking
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AvailablePlaces { get; set; }
    }

    public class Data
    {
        #region StringList
        public static List<string> StringList = new List<string> {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };
        #endregion

        #region ObservableStringList
        public static ObservableCollection<string> ObservableStringList = new ObservableCollection<string> {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };
        #endregion

        #region ProductList
        public static ObservableCollection<Parking> ParkingList = new ObservableCollection<Parking> {
            new Parking { ID = 1, Name = "Parking 1", AvailablePlaces = 67 },
            new Parking { ID = 2, Name = "Parking 2", AvailablePlaces = 100 },
            new Parking { ID = 3, Name = "Parking 3", AvailablePlaces = 280 },
            new Parking { ID = 4, Name = "Parking 4", AvailablePlaces = 1000 },
            new Parking { ID = 5, Name = "Parking 5", AvailablePlaces = 17 },
            new Parking { ID = 6, Name = "Parking 6", AvailablePlaces = 97 },
        };
        #endregion
    }
}
