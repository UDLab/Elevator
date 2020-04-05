using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Passenger
    {
        private int no;
        private int arrivedFloor;
        private int destinationFloor;
        private int arrivedTime;

        public int elevatorEnteringTime { get; set; }
        public int elevatorLeavingTime { get; set; }

        public Passenger(int no, int floor, int destination, int time)
        {
            this.no = no;
            arrivedFloor = floor;
            destinationFloor = destination;
            arrivedTime = time;
        }
        
        public string Print()
        {
            return String.Format("[{0}] Arrived at: t{1}, got on the elevator at t{2}, reached their destination at t{3}. Total time: {4} units", no, arrivedTime, elevatorEnteringTime, elevatorLeavingTime, (elevatorLeavingTime - arrivedTime));
        }
    }
}
