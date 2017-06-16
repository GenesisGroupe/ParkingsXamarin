using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Maps;
using System.Collections;

namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage, PositionListener
	{
		private bool mylock = true;
		public Location currentLocation;

		public ParkingGrandLyonPage()
		{
			InitializeComponent();
			initPositionListener();
			loadDatas();
			// Set Datasource to the Parking List
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;

		}

		public async void initPositionListener()
		{
			Geolocation geolocation = new Geolocation(this);
			await geolocation.getPositionListener();
		}



		public async void loadPosition()
		{
			Console.WriteLine("loadposition");
			Location location = new Location();
			currentLocation = await location.getCurrentPosition();
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

			loadPosition();
			//var result = await Network.GetCoordinates("50 quai Paul Sédallian Lyon");

			Network network = new Network();
			if (currentLocation == null)
			{
				return;
			}
			Task<string> task = network.GetParkings(20, currentLocation);


			string stringReturned = await task;

			if (stringReturned.Equals("") || stringReturned == null)
			{
				return;
			}
			var json = JObject.Parse(stringReturned);
			JArray featuresArray = (JArray)json["features"];

			ParkingManager parkingManager = ParkingManager.sharedManager();
			foreach (var item in featuresArray.Children())
			{

				Parking parking = Parking.createFromJson(item["properties"].ToString());
				JObject geometry = (JObject)item["geometry"];
				JArray coordinates = (JArray)geometry["coordinates"];
				double lat = (float)coordinates[1];
				double longitude = (float)coordinates[0];
				parking.location = new Location(longitude, lat);
				parkingManager.addParking(parking);
				Console.WriteLine("parking created");
				await parking.updateDistanceLocation(this);
				refreshListView();

			}

		}


		async void updateDistanceParkings()
		{
			Console.WriteLine("View controller update distance parking !");
			//Map.Pins.Clear();
			Console.WriteLine("update map");
			IList<Pin> pins = new List<Pin>();
			foreach (Parking parking in ParkingManager.sharedManager().allParkings)
			{
				await parking.updateDistanceLocation(this);
				if (Map != null)
				{
					
					var position = new Xamarin.Forms.Maps.Position(parking.location.latitude, parking.location.longitude); // Latitude, Longitude
					Console.WriteLine("creating pin");
					var pin = new Pin
					{
						Type = PinType.Place,
						Position = position,
						Label = "custom pin",
						Address = "custom detail info"
					};
					pins.Add(pin);
				}
			}

		}

		public void refreshListView()
		{
			if (mylock)
				{
				this.mylock = false;
					Device.BeginInvokeOnMainThread(() =>
						{
							//updateDistanceParkings();
							listView.ItemsSource = null;
							listView.ItemsSource = ParkingManager.sharedManager().allParkings;
							mylock = true;
						});
				}
		}

		public void positionChanged(Location location)
		{
			Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position((double)location.latitude, (double)location.longitude), Distance.FromMiles(1)));
			currentLocation = location;
			Network network = new Network();

			loadDatas();
			//network.GetParkings(20, location);
		}
	}
}
