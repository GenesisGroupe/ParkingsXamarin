using System;

using Newtonsoft.Json;
namespace ParkingGrandLyon
{
	public class Person
	{

		String lastname { get; set; }
		public static void convertPerson()
		{
			Person person = new Person { lastname = "laure" };
			Console.WriteLine("person: " + person.lastname);
			var json = JsonConvert.SerializeObject(person);
			Console.WriteLine("json : " + json);
			var newPerson = JsonConvert.DeserializeObject<Person>(json);
			Console.WriteLine("new perosn : " + person.lastname);
		}
	}
}
