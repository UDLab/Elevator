using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Floor
    {
        public List<Passenger> Queue;
        public FloorStatus Status;

        public Floor()
        {
            Queue = new List<Passenger>();
            Status = FloorStatus.NO_PRESSED;
        }
        public void Add(Passenger p)
        {
            if(p.GetDestination() != -1)
            {
                Queue.Add(p);
            }
        }

        public void Remove(Passenger p)
        {
            Queue.Remove(p);
        }
    }
    
    public enum FloorStatus
    {
        UP_PRESSED,
        NO_PRESSED,
        DOWN_PRESSED
    }
}
