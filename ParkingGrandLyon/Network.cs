using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ParkingGrandLyon
{
	public class Network
	{
		HttpClient client = new HttpClient();

		static string authorization = "Basic cGF1bGluZS5tb250Y2hhdUBnbWFpbC5jb206RXBpdGVjaDQyLjIwMDc=";
		static string parkingsUrl = "https://download.data.grandlyon.com/wfs/rdata?SERVICE=WFS&VERSION=2.0.0&outputformat=GEOJSON&maxfeatures=30&request=GetFeature&typename=pvo_patrimoine_voirie.pvoparkingtr&SRSNAME=urn:ogc:def:crs:EPSG::4326&bbox={0},{1},{2},{3}";
		static string directionsUrl = "https://maps.googleapis.com/maps/api/directions/json?origin={0},{1}&destination={2},{3}&mode=DRIVING&key=AIzaSyDTLYMpxG8TtIRP_e9_4EnjGvCFrZ6v2dg";

		public Network()
		{
			//GetLocations();
		}


		public async Task<string> GetParkings(int limit)
		{
			var currentLocation = Location.currentLocation;

			double lat1 = currentLocation.latitude - 0.01;
			double lat2 = currentLocation.latitude + 0.01;
			double long1 = currentLocation.longitude - 0.01;
			double long2 = currentLocation.longitude + 0.01;

			client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);

			string format = String.Format(parkingsUrl, long1 , lat1, long2, lat2);
			var response = await client.GetStringAsync(format);
			return response;
		}

		public async Task<string> GetDistanceBetweenPoints(Location currentLocation, Location destinationPoint)
		{
			string url = string.Format(directionsUrl, currentLocation.longitude, currentLocation.latitude, destinationPoint.longitude, destinationPoint.latitude);
			Console.WriteLine("url : " + url);
			var response = await client.GetStringAsync(url);
			return response;
		}



	}
}
