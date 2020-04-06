using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Building
    {
        public int NrOfFloors { get; set; }
        public List<Floor> Floors { get; set; }
        public Elevator Elevator { get; set; }
        public Building(int nr, int capacity)
        {
            NrOfFloors = nr;
            Elevator = new Elevator(capacity);
            Floors = new List<Floor>();
            for (int i = 0; i < nr; i++)
            {
                Floors.Add(new Floor());
            }
        }

        /// <summary>
        /// Adds a list of passengers to the specified floor.
        /// </summary>
        /// <param name="passengers"></param>
        /// <param name="nr"></param>
        public void AddPassengersToQueue(List<Passenger> passengers, int nr)
        {
            foreach(Passenger p in passengers)
            {
                Floors[nr].Add(p);   
            }
        }

        /// <summary>
        /// Removes a specific passenger from a specified floor.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="nr"></param>
        public void RemovePassenger(Passenger p, int nr)
        {
            Floors[nr].Remove(p);
        }
    }

}
