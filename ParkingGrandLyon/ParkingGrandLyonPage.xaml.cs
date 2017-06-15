using System;
<<<<<<< HEAD
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
=======
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using System.Linq;
>>>>>>> 52f625dc4e389a77cfe789c30966266e96913242

namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{
		public ParkingGrandLyonPage()
		{
			InitializeComponent();

<<<<<<< HEAD
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
=======



		}

		async void onClick(object sender, EventArgs e)
		{
			Network network = new Network();
			Task<string> task = network.GetParkings(100);

			string stringReturned = await task;
			var json = JObject.Parse(stringReturned);
			Console.WriteLine(json["values"]);
			JArray array = (Newtonsoft.Json.Linq.JArray)json["values"];
			ParkingManager parkingManager = ParkingManager.sharedManager();
			foreach (var item in array.Children())
			{
				parkingManager.addParking(Parking.createFromJson(item.ToString()));
			}

			Console.WriteLine("{0} parkings synchronizeds", parkingManager.countParkings());
			//Console.WriteLine("array type : " + array.GetType());
			//Parking p = Parking.createFromJson("{\"idfournisseur\": \"None\", \"commune\": \"DARDILLY\", \"reglementation\": \"Gratuit\", \"proprietaire\": \"GRAND LYON\", \"codetype\": \"5\", \"vocation\": \"None\", \"capacite2rm\": \"0\", \"idparking\": \"P578\", \"avancement\": \"Existant\", \"voieentree\": \"Avenue de Verdun\", \"gid\": \"1\", \"usage\": \"Libre\", \"voiesortie\": \"Avenue de Verdun\", \"nom\": \"Gendarmerie\", \"capacite\": \"5\", \"gabarit\": \"None\", \"capaciteautopartage\": \"0\", \"capacitevelo\": \"3\", \"annee\": \"2008\", \"capacitepmr\": \"1\", \"observation\": \"None\", \"typeparking\": \"Poche de stationnement\", \"parkingtempsreel\": \"Non\", \"gestionnaire\": \"GRAND LYON\", \"idparkingcriter\": \"None\", \"situation\": \"En surface\", \"fermeture\": \"Ouvert 24h/24h\" }");

		}

>>>>>>> 52f625dc4e389a77cfe789c30966266e96913242
	}
}
