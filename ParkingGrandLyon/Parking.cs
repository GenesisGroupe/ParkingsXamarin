using System;
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Parking
	{
		String nom { get; set; }
		//String idparking;
		//int idparkingcriter;
		//String commune;
		//String proprietaire;
		//String gestionnaire;
		//String idfournisseur;
		//String voieentree;
		//String voiesortie;
		//String avancement;
		//int annee;
		//String situation;
		//String parkingtempsreel;
		//float gabarit;
		//int capacite;
		//int capacite2rm;
		//int capacitevelo;
		//int capaciteautopartage;
		//int capacitepmr;
		//String usage;
		//String vocation;
		//String reglementation;
		//String fermeture;
		//String observation;
		//int codetype;
		//int gid;
		//Location the_geom;


		public static Parking createFromJson(String json)
		{
			Parking parkingTest = new Parking { nom = "myParking" };
			Console.Out.WriteLine("parking cree : " + parkingTest.nom);
			var myJson = JsonConvert.SerializeObject(parkingTest);
			Console.Out.WriteLine("serialized object : " + myJson);
			Parking deserializedParking = JsonConvert.DeserializeObject<Parking>(myJson);
			Console.Out.WriteLine("deserialized parking :  " + deserializedParking.nom);
			return null;
			//Parking p = JsonConvert.DeserializeObject<Parking>(json);
			//Console.Out.WriteLine("json object : "  + json);
			//Console.Out.WriteLine("deserialized object : " + p.nom);
			//return p;
		}
			
	}
}
