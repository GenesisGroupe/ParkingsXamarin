using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ParkingGrandLyon {
    public class Network {
        HttpClient client = new HttpClient();

        static string authorization = "Basic cGF1bGluZS5tb250Y2hhdUBnbWFpbC5jb206RXBpdGVjaDQyLjIwMDc=";
        public Network() {
            GetLocations();
        }

        public async void GetParkings(int limit) {

			client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);

			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/all.json?maxfeatures="+limit);
            Console.WriteLine(response);
		}

        public async void GetLocations() {

			client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);

			var response = await client.GetStringAsync("https://download.data.grandlyon.com/wfs/rdata?SERVICE=WFS&VERSION=2.0.0&outputformat=GEOJSON&maxfeatures=30&request=GetFeature&typename=pvo_patrimoine_voirie.pvoparkingtr&SRSNAME=urn:ogc:def:crs:EPSG::4171");
			Console.WriteLine(response);
            var myJson = JObject.Parse(response);

            Console.WriteLine(myJson["features"]);
            //Location location = Location.createFromJson()
           

		}

    }
}
