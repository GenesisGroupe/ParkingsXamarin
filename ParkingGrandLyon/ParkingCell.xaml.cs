using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
	public class ParkingCell : ViewCell
	{
		public static readonly BindableProperty NameProperty =
		  BindableProperty.Create("Name", typeof(string), typeof(ParkingCell), "");

		public string Name
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public static readonly BindableProperty CategoryProperty =
		  BindableProperty.Create("Category", typeof(string), typeof(ParkingCell), "");

		public string Category
		{
			get { return (string)GetValue(CategoryProperty); }
			set { SetValue(CategoryProperty, value); }
		}

	}
}
