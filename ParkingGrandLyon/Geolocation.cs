using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
    public class Geolocation
    {
		public IGeolocator locator = CrossGeolocator.Current;
        public PositionListener mListener;

		public Geolocation()
        {
        
        }

        public Geolocation(PositionListener listener) {
            mListener = listener;
        }

		public async Task<Location> getCurrentPosition()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100; //100 is new default



			if (locator.AllowsBackgroundUpdates)
			{
				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

				Location location = new Location((float)position.Longitude, (float)position.Latitude);

				return location;
			}

			Location currentLocation = new Location((float)45.789285, (float)4.814896);

			return currentLocation;
		}

		public async Task<bool> getPositionListener()
		{
			this.locator.DesiredAccuracy = 100;
			this.locator.PositionChanged += Current_PositionChanged;
			return await this.locator.StartListeningAsync(10, 1, false);
		}


		private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
                if (mListener != null) {
                    mListener.positionChanged(e.Position);
                }
			});
		}
    }

	public interface PositionListener
	{
        void positionChanged(Position position);
	}
}
