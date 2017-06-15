using System;
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Parking
	{
		public String nom { get; set; }
public String idparking;
public int idparkingcriter;
public String commune;
public String proprietaire;
public String gestionnaire;
public String idfournisseur;
public String voieentree;
public String voiesortie;
public String avancement;
public int annee;
public String situation;
public String parkingtempsreel;
public float gabarit;
public int capacite;
public int capacite2rm;
public int capacitevelo;
public int capaciteautopartage;
public int capacitepmr;
public String usage;
public String vocation;
public String reglementation;
public String fermeture;
public String observation;
public int codetype;
public int gid;
public Location the_geom; 


		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			Console.Out.WriteLine("json object : "  + json);
			Console.Out.WriteLine("deserialized object : " + p.nom);
			return p;
		}
			
	}
}
