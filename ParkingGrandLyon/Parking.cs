using System;
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Parking
	{
		public String pkgid { get; set; }
		public String nom { get; set; }
		public String gestionnaire { get; set; }
		public String id_fournisseur { get; set; }
		public String capacitevoiture { get; set; }
		public String capacitemoto { get; set; }
		public String capacitevelo { get; set; }
		public String capaciteautopartage { get; set; }
		public String capacitepmr { get; set; }
		public String etat { get; set; }
		public String etat_code { get; set; }
		public String gid { get; set; }
		public String last_update { get; set; }
		public String last_update_fme { get; set; }
		public Location location { get; set; }
		public int distanceToLocation { get; set; }

		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			Console.Out.WriteLine("json object : " + json);
			Console.Out.WriteLine("deserialized object : " + p.capacitevoiture);
			return p;
		}

	}
}
