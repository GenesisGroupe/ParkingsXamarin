using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public class Location
	{
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string distance { get; set; }
		public static Location currentLocation = new Location(45.789285, 4.814896);

		public Location(double longitude, double lat)
		{
			this.latitude = lat;
			this.longitude = longitude;
			this.distance = "distance inconnue";
		}

		public Location()
		{

		}

		public async Task<string> ParseMapsResponse(Task<string> responseTask)
		{
			string response = await responseTask;

			JObject jsonResponse = JObject.Parse(response);
			Console.Write("response task : " + jsonResponse);
			JArray jsonRoutes = (JArray)jsonResponse["routes"];
			if (jsonRoutes.Count > 0)
			{
				Console.WriteLine("jsonRoutes count : " + jsonRoutes.Count);
				JObject route = (JObject)jsonRoutes[0];
				JArray legs = (JArray)route["legs"];
				JObject leg = (JObject)legs[0];
				JObject distance = (JObject)leg["distance"];
				//int dist = (int)distance["value"];
				Console.WriteLine("distance: " + distance);
				this.distance = (string)distance["text"];

			}
			return this.distance;
		}


		public async Task<Location> getCurrentPosition()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100; //100 is new default

			if (locator.AllowsBackgroundUpdates)
			{
				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

				Location location = new Location((float)position.Longitude, (float)position.Latitude);

				return location;
			}

			Location currentLocation = new Location((float)45.789285, (float)4.814896);

			return currentLocation;
		}

	}
}
