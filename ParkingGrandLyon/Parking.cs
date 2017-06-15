using System;
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Parking
	{
		public String nom { get; set; }
public String idparking { get; set; }
public String idparkingcriter { get; set; }
public String commune { get; set; }
public String proprietaire { get; set; }
public String gestionnaire { get; set; }
public String idfournisseur { get; set; }
public String voieentree { get; set; }
public String voiesortie { get; set; }
public String avancement { get; set; }
public String annee { get; set; }
public String situation { get; set; }
public String parkingtempsreel { get; set; }
public String gabarit { get; set; }
public String capacite { get; set; }
public String capacite2rm { get; set; }
public String capacitevelo { get; set; }
public String capaciteautopartage { get; set; }
public String capacitepmr { get; set; }
public String usage { get; set; }
public String vocation { get; set; }
public String reglementation { get; set; }
public String fermeture { get; set; }
public String observation { get; set; }
public String codetype { get; set; }
public String gid { get; set; }
public Location the_geom { get; set; }


		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			Console.Out.WriteLine("json object : "  + json);
			Console.Out.WriteLine("deserialized object : " + p.capacite);
			return p;
		}
			
	}
}
