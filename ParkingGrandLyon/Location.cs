using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ParkingGrandLyon
{
	public class Location
	{
		public double latitude { get; set; }
		public double longitude { get; set; }

		public Location(double longitude, double lat)
		{
			this.latitude = lat;
			this.longitude = longitude;
		}


		public async static Task<int> ParseMapsResponse(Task<string> responseTask)
		{
			string response = await responseTask;

			JObject jsonResponse = JObject.Parse(response);
			JArray jsonRoutes = (JArray)jsonResponse["routes"];
			JObject route = (JObject) jsonRoutes[0];
			JArray legs = (JArray)route["legs"];
			JObject leg = (JObject)legs[0]; 
			JObject distance = (JObject)leg["distance"];
			Console.WriteLine("response geopoint : " + distance);
			int dist = (int)distance["value"];
			Console.WriteLine("distance to parking : " + dist);
			return dist;
		}
	}
}
