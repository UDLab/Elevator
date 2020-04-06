using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Passenger
    {
        private static int ID = 0;
        private int no;
        private int arrivedFloor;
        private int destinationFloor;
        private int arrivedTime;

        public int elevatorEnteringTime { get; set; }
        public int elevatorLeavingTime { get; set; }

        /// <summary>
        /// Increments shared id-variable. Sets initial values.
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="destination"></param>
        /// <param name="time"></param>
        public Passenger(int floor, int destination, int time)
        {
            ID++;
            no = ID;
            arrivedFloor = floor;
            destinationFloor = destination;
            arrivedTime = time;
        }

        public int GetDestination()
        {
            return destinationFloor;
        }
        
        /// <summary>
        /// For testing output.
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return String.Format("[{0}] Arrived: t{1} - enter t{2} - destination t{3} - total {4}ms", no, arrivedTime, elevatorEnteringTime, elevatorLeavingTime, (elevatorLeavingTime - arrivedTime));
        }

        public void AddEnteringTime(int time)
        {
            elevatorEnteringTime = time;
        }

        public void AddLeavingTime(int time)
        {
            elevatorLeavingTime = time;
        }
    }
}
