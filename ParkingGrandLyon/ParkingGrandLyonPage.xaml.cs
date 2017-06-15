using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{
		public ParkingGrandLyonPage()
		{
			InitializeComponent();




		}

		void onClick(object sender, EventArgs e)
		{
			Console.WriteLine("hello");
			Parking p = Parking.createFromJson("{\"idfournisseur\": \"None\", \"commune\": \"DARDILLY\", \"reglementation\": \"Gratuit\", \"proprietaire\": \"GRAND LYON\", \"codetype\": \"5\", \"vocation\": \"None\", \"capacite2rm\": \"0\", \"idparking\": \"P578\", \"avancement\": \"Existant\", \"voieentree\": \"Avenue de Verdun\", \"gid\": \"1\", \"usage\": \"Libre\", \"voiesortie\": \"Avenue de Verdun\", \"nom\": \"Gendarmerie\", \"capacite\": \"5\", \"gabarit\": \"None\", \"capaciteautopartage\": \"0\", \"capacitevelo\": \"3\", \"annee\": \"2008\", \"capacitepmr\": \"1\", \"observation\": \"None\", \"typeparking\": \"Poche de stationnement\", \"parkingtempsreel\": \"Non\", \"gestionnaire\": \"GRAND LYON\", \"idparkingcriter\": \"None\", \"situation\": \"En surface\", \"fermeture\": \"Ouvert 24h/24h\" }");

		}

	}
}
