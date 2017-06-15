using System;
using System.Net.Http;

namespace ParkingGrandLyon {
    public class Network {
        HttpClient client = new HttpClient();
        public Network() {
            GetLocations();
        }

        public async void GetParkings(int limit) {
			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/all.json?maxfeatures="+limit);
            Console.WriteLine(response);
		}

        public async void GetLocations() {
			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/the_geom.json");
			Console.WriteLine(response);


		}

    }
}
