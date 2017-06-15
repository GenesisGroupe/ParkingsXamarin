using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{
		public ParkingGrandLyonPage()
		{
			InitializeComponent();

            // Set Datasource to the Parking List
            listView.ItemsSource = Data.ParkingList;

            // Init the map
            initMap();
		}
            
        // Init the map of the application
        void initMap() {
            var map = new Map(MapSpan.FromCenterAndRadius(
                new Position(36.8961, 10.1865),
                Distance.FromMiles(0.5)
            )
        }

        // Fired when the user tap a cell
        // get the Parking Object selected
        // And show it on the map
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e){
            if (e.SelectedItem != null) {
                var selectedParking = e.SelectedItem as Parking;
                DisplayAlert("You selected", selectedParking.Name, "OK");
            }
        }
	}
}
