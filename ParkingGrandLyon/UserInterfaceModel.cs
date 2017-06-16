using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingGrandLyon
{
    public class UserInterfaceModel
    {

		private Action _rowAnimation;

		public UserInterfaceModel(Action rowAnimation)
        {
             _rowAnimation = rowAnimation;
        }

		public ICommand Animate
		{
			get
			{
				return new Command((o) =>
				{
					_rowAnimation.Invoke();
				});
			}
		}
    }
}
