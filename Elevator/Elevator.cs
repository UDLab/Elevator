using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Elevator
    {
        public int Capacity { get; set; }
        public int AtFloor { get; set; }
        public ElevatorStatus Status { get; set; }
        public List<Passenger> Riders { get; set; }

        /// <summary>
        /// Will always start at floor 0, going up.
        /// </summary>
        /// <param name="capacity"></param>
        public Elevator(int capacity)
        {
            Capacity = capacity;
            Status = ElevatorStatus.GOING_UP;
            AtFloor = 0;
            Riders = new List<Passenger>();
        }

        public void Add(Passenger p)
        {
            Riders.Add(p);
        }

        public void Remove(Passenger p)
        {
            Riders.Remove(p);
        }

        public bool HasRoom()
        {
            return Riders.Count < Capacity;
        }

        /// <summary>
        /// If passengers destination is below an elevator going downwards, or above an elevator going upwards.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool GoingCorrectDirection(Passenger p)
        {
            return p.GetDestination() < AtFloor && (Status == ElevatorStatus.GOING_DOWN || Status == ElevatorStatus.STATIC) || 
                p.GetDestination() > AtFloor && (Status == ElevatorStatus.GOING_UP || Status == ElevatorStatus.STATIC);
        }

        public void Move(int i)
        {
            AtFloor += i;
            if(AtFloor == 0)
            {
                Status = ElevatorStatus.GOING_UP;
            } else if(AtFloor == 9)
            {
                Status = ElevatorStatus.GOING_DOWN;
            }
        }

        public void Print()
        {
            if(Riders.Count < 10)
            {
                Console.Write(" [{0}] ", Riders.Count);
            } else
            {
                Console.Write(" [F] ");
            }
        }
    }

    public enum ElevatorStatus
    {
        GOING_UP,
        STATIC,
        GOING_DOWN
    }
}
