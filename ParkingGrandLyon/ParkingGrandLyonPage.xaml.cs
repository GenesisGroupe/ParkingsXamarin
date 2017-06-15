using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;


namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{

		Location currentLocation = new Location(45.789285, 4.814896);
		public ParkingGrandLyonPage()
		{
			InitializeComponent();
			loadDatas();
			// Set Datasource to the Parking List
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;

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
			Network network = new Network();
			Task<string> task = network.GetParkings(100);

			string stringReturned = await task;
			var json = JObject.Parse(stringReturned);
			JArray featuresArray = (JArray)json["features"];

			ParkingManager parkingManager = ParkingManager.sharedManager();
			foreach (var item in featuresArray.Children())
			{
				Parking parking = Parking.createFromJson(item["properties"].ToString());
				JObject geometry = (JObject)item["geometry"];
				JArray coordinates = (JArray)geometry["coordinates"];
				double lat = (double)coordinates[1];
				double longitude = (double)coordinates[0];
				parking.location = new Location(longitude, lat);
				parkingManager.addParking(parking);
				Task<string> jsonPoint = network.GetDistanceBetweenPoints(currentLocation, parking.location);
				Location.ParseMapsResponse(jsonPoint);
			}
			Parking firstParking = (Parking)ParkingManager.sharedManager().allParkings[0];
			Console.WriteLine("longitude : " + firstParking.location.longitude + ", latitude : " + firstParking.location.latitude);

			Console.WriteLine("{0} parkings synchronizeds", parkingManager.countParkings());
			listView.ItemsSource = null;
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;

		}

	}
}
