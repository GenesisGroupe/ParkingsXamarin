﻿using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Threading.Tasks;

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

		public ICommand btnGoCommand { get; set; }

		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			p.setEtat(p.etat);
			Console.Out.WriteLine("json object : " + json);
			Console.Out.WriteLine("deserialized object : " + p.capacitevoiture);
			p.setBtnGoCommand();
			return p;
		}

		public void setBtnGoCommand()
		{
			btnGoCommand = new Command(param => GoCommand((Location)param));
		}

		public void GoCommand(Location location)
		{
			//here you create your call to the startTimer() method
			Console.Out.WriteLine("GO " + location.latitude + " / " + location.longitude);
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					Device.OpenUri(new Uri(string.Format("http://maps.apple.com/?q={0},{1}", location.latitude, location.longitude)));
					break;
				case Device.Android:
					Device.OpenUri(new Uri(string.Format("geo:0,0?q={0},{1}", location.latitude, location.longitude)));
					break;
				case Device.WinPhone:
					Device.OpenUri(new Uri(string.Format("bingmaps:?where={0},{1}", location.latitude, location.longitude)));
					break;
				case Device.Windows:
				default:
					break;
			}
		}

		public Task<string> updateDistanceLocation()
		{
			Network network = new Network();
			Task<string> jsonPoint = network.GetDistanceBetweenPoints(Location.currentLocation, this.location);
			return jsonPoint;
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
				Double totInt = Double.Parse(totalAvailablePlaces);
				Double capInt = Double.Parse(capacitevoiture);
				if ((totInt / capInt * 100) < 3)
				{
					parkingViewColor = "#d36b78";
				}
				else if ((totInt / capInt * 100) < 10)
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
