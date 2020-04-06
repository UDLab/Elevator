using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Floor
    {
        public List<Passenger> Queue;

        public Floor()
        {
            Queue = new List<Passenger>();
        }
        public void Add(Passenger p)
        {
            Queue.Add(p);
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
