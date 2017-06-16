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

        public async Task<Location> getCurrentPosition() {
            var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100; //100 is new default

            if (locator.AllowsBackgroundUpdates) {
				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

				Location location = new Location((float)position.Longitude, (float)position.Latitude);

				return location;
            } 

            Location currentLocation = new Location((float)45.789285, (float)4.814896);

            return currentLocation;
        }

	}
}
