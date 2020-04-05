using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class Passenger
    {
        private int no;
        private int arrivedFloor;
        private int destinationFloor;
        private int arrivedTime;
        public int elevatorEnteringTime;
        public int elevatorLeavingTime;

        public Passenger(int no, int floor, int destination, int time)
        {
            this.no = no;
            arrivedFloor = floor;
            destinationFloor = destination;
            arrivedTime = time;
        }
    }
}
