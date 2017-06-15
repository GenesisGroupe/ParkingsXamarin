using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace ParkingGrandLyon
{
	public class Parking
	{
		public String pkgid { get; set; }
		public String nom { get; set; }
		public String gestionnaire { get; set; }
		public String id_fournisseur { get; set; }
		public String capacitevoiture { get; set; }
		public String capacitemoto { get; set; }
		public String capacitevelo { get; set; }
		public String capaciteautopartage { get; set; }
		public String capacitepmr { get; set; }
		public String etat { get; set; }
		public String etat_code { get; set; }
		public String gid { get; set; }
		public String last_update { get; set; }
		public String last_update_fme { get; set; }
		public Location location { get; set; }

		public String parkingViewColor { get; set; }
		public String totalAvailablePlaces { get; set; }
		public bool noDataAvailable { get; set; }

		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			p.setEtat(p.etat);
			Console.Out.WriteLine("json object : " + json);
			Console.Out.WriteLine("deserialized object : " + p.capacitevoiture);
			return p;
		}

		public void setEtat(String etat)
		{
			string resultString = "";
			resultString = Regex.Match(etat, @"\d+").Value;

			if (resultString == "")
			{
				noDataAvailable = true;
				totalAvailablePlaces = "?";
				parkingViewColor = "#d8d8d8";
			}
			else
			{
				totalAvailablePlaces = resultString;
				Int32 totInt = Int32.Parse(totalAvailablePlaces);
				if (totInt == 0)
				{
					parkingViewColor = "#d36b78";
				}
				else if (totInt < 4)
				{
					parkingViewColor = "#f5c923";
				}
				else
				{
					parkingViewColor = "#50e3c2";
				}

			}
		}
	}
}
