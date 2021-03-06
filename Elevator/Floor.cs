﻿using System;
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

        /// <summary>
        /// Adds passenger if destination exists.
        /// </summary>
        /// <param name="p"></param>
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

        public void Print()
        {
            foreach(Passenger p in Queue)
            {
                Console.Write(" {0}", p.GetDestination());
            }
        }
    }
    
    public enum FloorStatus
    {
        UP_PRESSED,
        NO_PRESSED,
        DOWN_PRESSED
    }
}
