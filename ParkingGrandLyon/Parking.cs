using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkingGrandLyon
{
    public class Parking
    {
        public Parking()
        {
            public int ID { get; set; }
            public string name { get; set; }
            public int availablePlaces { get; set; }
        }
    }
=======
using Newtonsoft.Json;

namespace ParkingGrandLyon
{
	public class Parking
	{
		public String nom { get; set; }
public String idparking;
public String idparkingcriter;
public String commune;
public String proprietaire;
public String gestionnaire;
public String idfournisseur;
public String voieentree;
public String voiesortie;
public String avancement;
public String annee;
public String situation;
public String parkingtempsreel;
public String gabarit;
public String capacite;
public String capacite2rm;
public String capacitevelo;
public String capaciteautopartage;
public String capacitepmr;
public String usage;
public String vocation;
public String reglementation;
public String fermeture;
public String observation;
public String codetype;
public String gid;
public Location the_geom; 


		public static Parking createFromJson(String json)
		{
			Parking p = JsonConvert.DeserializeObject<Parking>(json);
			Console.Out.WriteLine("json object : "  + json);
			Console.Out.WriteLine("deserialized object : " + p.nom);
			return p;
		}
			
	}
>>>>>>> 52f625dc4e389a77cfe789c30966266e96913242
}
