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
		static string parkingsUrl = "https://download.data.grandlyon.com/wfs/rdata?SERVICE=WFS&VERSION=2.0.0&outputformat=GEOJSON&maxfeatures=30&request=GetFeature&typename=pvo_patrimoine_voirie.pvoparkingtr&SRSNAME=urn:ogc:def:crs:EPSG::4171";
		static string directionsUrl = "https://maps.googleapis.com/maps/api/directions/json?origin={0},{1}&destination={2},{3}&mode=DRIVING&key=AIzaSyDTLYMpxG8TtIRP_e9_4EnjGvCFrZ6v2dg";

		public Network()
		{
			//GetLocations();
		}


		public async Task<string> GetParkings(int limit)
		{
			client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);
			var response = await client.GetStringAsync(parkingsUrl);
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
