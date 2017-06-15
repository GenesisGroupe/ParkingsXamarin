using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new ParkingGrandLyonPage();
            Network network = new Network();
			//Parking p = Parking.createFromJson("{\"nom\":\"test\" }");

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
