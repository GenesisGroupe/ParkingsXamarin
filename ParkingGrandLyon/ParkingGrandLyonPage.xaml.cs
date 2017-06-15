using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;


namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{
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
				float lat = (float)coordinates[1];
				float longitude = (float)coordinates[0];
				parking.location = new Location(longitude, lat);
				parkingManager.addParking(parking);
			}

			Console.WriteLine("{0} parkings synchronizeds", parkingManager.countParkings());
			listView.ItemsSource = null;
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;

		}

	}
}
