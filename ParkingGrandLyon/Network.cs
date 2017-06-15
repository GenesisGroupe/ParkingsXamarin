using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingGrandLyon {
    public class Network {
        HttpClient client = new HttpClient();
        public Network() {
            GetLocations();
        }

        public async Task<String> GetParkings(int limit) {
			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/all.json?maxfeatures="+limit);
            Console.WriteLine(response);
			return response;
		}

        public async void GetLocations() {
			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/the_geom.json");
			Console.WriteLine(response);


		}

    }
}
