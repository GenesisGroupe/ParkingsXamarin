using System;
using System.Collections;

namespace ParkingGrandLyon
{
	public class ParkingManager
	{
		public ArrayList allParkings;

		//This is known as early binding or initialization  
		private static ParkingManager _instance = new ParkingManager();

		//Constructor is marked as private   
		//so that the instance cannot be created   
		//from outside of the class  
		private ParkingManager()
		{
			this.allParkings = new ArrayList();
		}

		//Static method which allows the instance creation  
		static internal ParkingManager sharedManager()
		{
			//All you need to do it is just return the  
			//already initialized which is thread safe  
			return _instance;
		}


		public void addParking(Parking parking)
		{
            if (!parkingExists(parking))
			{
				this.allParkings.Add(parking);
			}
		}

        public Boolean parkingExists(Parking parking) {
            foreach(Parking p in this.allParkings) {
                if (p.nom == parking.nom) {
                    return true;
                }
            }
            return false;
        }

		public int countParkings()
		{
			return this.allParkings.Count;
		}
	}
}
