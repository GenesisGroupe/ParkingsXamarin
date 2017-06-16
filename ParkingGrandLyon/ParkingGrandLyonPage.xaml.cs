using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;


namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage, PositionListener
	{
		public ParkingGrandLyonPage()
		{
			InitializeComponent();
			//loadPosition();
			loadDatas();
			// Set Datasource to the Parking List
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;
			updateDistanceParkings();
		}


		public async void loadPosition()
		{
			Console.WriteLine("loadposition");
			Location location = new Location();
			await location.getCurrentPosition();
		}


		// Fired when the user tap a cell
		// get the Parking Object selected
		// And show it on the map
		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				var selectedParking = e.SelectedItem as Parking;
				DisplayAlert("You selected", selectedParking.nom, "OK");
			}
		}


		// Function to load datas asynchronislou
		async void loadDatas()
		{


			Geolocation geolocation = new Geolocation(this);
			await geolocation.getPositionListener();

			Network network = new Network();
			Task<string> task = network.GetParkings(300);

			string stringReturned = await task;
			var json = JObject.Parse(stringReturned);
			JArray featuresArray = (JArray)json["features"];

			ParkingManager parkingManager = ParkingManager.sharedManager();
			foreach (var item in featuresArray.Children())
			{
				
				Parking parking = Parking.createFromJson(item["properties"].ToString());
				JObject geometry = (JObject)item["geometry"];
				JArray coordinates = (JArray)geometry["coordinates"];
				double lat = (float)coordinates[0];
				double longitude = (float)coordinates[1];
				parking.location = new Location(longitude, lat);
				parkingManager.addParking(parking);
				Console.WriteLine("parking created");
                refreshListView();
				await parking.updateDistanceLocation(this);
			}


		}

		public void positionChanged(Position position)
		{
			Console.WriteLine("Position changed : {0}, {1}.", position.Latitude, position.Longitude);
		}

		async void updateDistanceParkings()
		{
			Console.WriteLine("update distance parking !");
			foreach (Parking parking in ParkingManager.sharedManager().allParkings)
			{
				await parking.updateDistanceLocation(this);
			}
		}

		public void refreshListView()
		{
			listView.ItemsSource = null;
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;

		}
	}
}
