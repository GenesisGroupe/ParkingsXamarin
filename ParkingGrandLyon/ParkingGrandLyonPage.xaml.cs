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
				JArray array = (JArray)json["values"];
				ParkingManager parkingManager = ParkingManager.sharedManager();
				foreach (var item in array.Children())
				{
					parkingManager.addParking(Parking.createFromJson(item.ToString()));
				}

				Console.WriteLine("{0} parkings synchronizeds", parkingManager.countParkings());
			listView.ItemsSource = null;
			listView.ItemsSource = ParkingManager.sharedManager().allParkings;
			//Console.WriteLine("array type : " + array.GetType());
			//Parking p = Parking.createFromJson("{\"idfournisseur\": \"None\", \"commune\": \"DARDILLY\", \"reglementation\": \"Gratuit\", \"proprietaire\": \"GRAND LYON\", \"codetype\": \"5\", \"vocation\": \"None\", \"capacite2rm\": \"0\", \"idparking\": \"P578\", \"avancement\": \"Existant\", \"voieentree\": \"Avenue de Verdun\", \"gid\": \"1\", \"usage\": \"Libre\", \"voiesortie\": \"Avenue de Verdun\", \"nom\": \"Gendarmerie\", \"capacite\": \"5\", \"gabarit\": \"None\", \"capaciteautopartage\": \"0\", \"capacitevelo\": \"3\", \"annee\": \"2008\", \"capacitepmr\": \"1\", \"observation\": \"None\", \"typeparking\": \"Poche de stationnement\", \"parkingtempsreel\": \"Non\", \"gestionnaire\": \"GRAND LYON\", \"idparkingcriter\": \"None\", \"situation\": \"En surface\", \"fermeture\": \"Ouvert 24h/24h\" }");

		}

	}
	}
