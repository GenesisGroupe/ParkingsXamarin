using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public partial class ParkingGrandLyonPage : ContentPage
	{
		public ParkingGrandLyonPage()
		{
			InitializeComponent();




		}

		private Command _clickCommand;

		public ICommand ClickCommand
		{
			get
			{
				if (_clickCommand == null)
				{
					_clickCommand = new Command(() => test());
				}

				return _clickCommand;
			}
		}
			void test()
		{
			Console.WriteLine("button clicked");
			Person.convertPerson();

		}

	}
}
