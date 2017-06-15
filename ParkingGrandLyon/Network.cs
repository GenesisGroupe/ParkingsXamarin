using System;
using System.Net.Http;

namespace ParkingGrandLyon
{
    public class Network {
        HttpClient client = new HttpClient();
        public Network() {
            GetParkings(10);
        }

        public async void GetParkings(int limit) {
			var response = await client.GetStringAsync("https://download.data.grandlyon.com/ws/grandlyon/pvo_patrimoine_voirie.pvoparking/all.json?maxfeatures="+limit);
            Console.WriteLine(response);
		}


    }
}
