﻿using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public class Location
	{
		public float latitude { get; set; }
		public float longitude { get; set; }

		public Location(float longitude, float lat)
		{
			this.latitude = lat;
			this.longitude = longitude;
		}

		public Location()
		{
			
		}



	}

  
}
