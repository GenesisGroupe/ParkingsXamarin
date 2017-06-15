using System;
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Location
	{
		double latitude { get; set; }
		double longitude { get; set; }

		public Location()
		{
		}

		public static Location createFromJson(String json)
		{
            Location locationTest = new Location { latitude = 49.1, longitude = 29.1 };
            Console.Out.WriteLine("parking cree : " + locationTest.latitude);
			var myJson = JsonConvert.SerializeObject(locationTest);
			Console.Out.WriteLine("serialized object : " + myJson);
			Location deserializedLocation = JsonConvert.DeserializeObject<Location>(myJson);
			Console.Out.WriteLine("deserialized location :  " + deserializedLocation.latitude);
			return deserializedLocation;
			//Parking p = JsonConvert.DeserializeObject<Parking>(json);
			//Console.Out.WriteLine("json object : "  + json);
			//Console.Out.WriteLine("deserialized object : " + p.nom);
			//return p;
		}
	}
}
