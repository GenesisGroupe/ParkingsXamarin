using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ParkingGrandLyon
{
	public class Network
	{
		static HttpClient client = new HttpClient();

		static string authorization = "Basic cGF1bGluZS5tb250Y2hhdUBnbWFpbC5jb206RXBpdGVjaDQyLjIwMDc=";
		static string parkingsUrl = "https://download.data.grandlyon.com/wfs/rdata?SERVICE=WFS&VERSION=2.0.0&outputformat=GEOJSON&maxfeatures=30&request=GetFeature&typename=pvo_patrimoine_voirie.pvoparkingtr&SRSNAME=urn:ogc:def:crs:EPSG::4326&bbox={0},{1},{2},{3}";
		static string directionsUrl = "https://maps.googleapis.com/maps/api/directions/json?origin={0},{1}&destination={2},{3}&mode=DRIVING&key=AIzaSyDTLYMpxG8TtIRP_e9_4EnjGvCFrZ6v2dg";

		public async Task<string> GetParkings(int limit, Location currentLocation)
		{
			double lat1 = currentLocation.latitude - 0.01;
			double lat2 = currentLocation.latitude + 0.01;
			double long1 = currentLocation.longitude - 0.01;
			double long2 = currentLocation.longitude + 0.01;
			Console.WriteLine("long1 : " + long1);
			Console.WriteLine("lat1 : " + lat1);
			Console.WriteLine("long2 : " + long2);
			Console.WriteLine("lat2 : " + lat2);
			client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);
			string slong1 = string.Format("{0}", long1);
			string slong2 = string.Format("{0}", long2);
			string slat1 = string.Format("{0}", lat1);

			string slat2 = string.Format("{0}", lat2);
			slong1 = slong1.Replace(",", ".");
			slong2 = slong2.Replace(",", ".");
			slat1 = slat1.Replace(",", ".");
			slat2 = slat2.Replace(",", ".");
			Console.WriteLine("slong1 : " + slong1);
			Console.WriteLine("slat1 : " + slat1);
			Console.WriteLine("slong2 : " + slong2);
			Console.WriteLine("slat2 : " + slat2);

			string format = String.Format(parkingsUrl, slong1, slat1, slong2, slat2);
			Console.WriteLine("GetParkings : " + format);
			var response = await client.GetStringAsync(format);
			Console.Write("resopnse : " + response);
			return response;
		}

		//Get coordinates of a string address
		public static async Task<Location> GetCoordinates(String address)
		{
			String addressToCoordinatesUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + Uri.EscapeUriString(address) + ",+CA&key=" + "AIzaSyAc3OpfgsUvk7Uxj0CUN-XfGTNvIIcI-AQ";
			Console.WriteLine("GetCoordinates : " + addressToCoordinatesUrl);
			var response = await client.GetStringAsync(addressToCoordinatesUrl);
			var json = JObject.Parse(response);
			JArray results = (JArray)json["results"];
			if (results.Count < 1)
			{
				return null;
			}
			var geometry = results[0]["geometry"];
			var loc = geometry["location"];

			Location location = new Location((float)loc["lat"], (float)loc["lng"]);
			return location;
		}

		public async Task<string> GetDistanceBetweenPoints(Location currentLocation, Location destinationPoint)
		{

			string slong1 = string.Format("{0}", currentLocation.longitude);
			string slong2 = string.Format("{0}", destinationPoint.longitude);
			string slat1 = string.Format("{0}", currentLocation.latitude);

			string slat2 = string.Format("{0}", destinationPoint.latitude);
			slong1 = slong1.Replace(",", ".");
			slong2 = slong2.Replace(",", ".");
			slat1 = slat1.Replace(",", ".");
			slat2 = slat2.Replace(",", ".");
			string url = string.Format(directionsUrl, slong1, slat1, slat2, slong2);
			Console.WriteLine("url : " + url);
			var response = await client.GetStringAsync(url);
			return response;
		}



	}
}
