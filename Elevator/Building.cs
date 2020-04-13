using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Building
    {
        public int NrOfFloors { get { return Floors.Count; } }
        public int ElevatorAtFloor { get { return Elevator.AtFloor; } }
        public List<Floor> Floors { get; set; }
        public Elevator Elevator { get; set; }
        public Building(int nrOfFloors, int elevatorCapacity)
        {
            Elevator = new Elevator(elevatorCapacity);
            Floors = new List<Floor>();
            for (int i = 0; i < nrOfFloors; i++)
            {
                Floors.Add(new Floor());
            }
        }

        /// <summary>
        /// If any floor still has any passengers in their queue.
        /// </summary>
        /// <returns></returns>
        public bool HasWaitingPassengers()
        {
            foreach(Floor f in Floors)
            {
                if(f.Queue.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If elevator has any passengers in it.
        /// </summary>
        /// <returns></returns>
        public bool PassengersInElevator()
        {
            return Elevator.Riders.Count > 0;
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
