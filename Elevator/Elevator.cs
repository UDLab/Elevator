﻿using System;
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

        public bool GoingCorrectDirection(Passenger p)
        {
            return p.GetDestination() < AtFloor && (Status == ElevatorStatus.GOING_DOWN || Status == ElevatorStatus.STATIC) || 
                p.GetDestination() > AtFloor && (Status == ElevatorStatus.GOING_UP || Status == ElevatorStatus.STATIC);
        }

        public void Move(int i)
        {
            AtFloor += i;
        }
    }

    public enum ElevatorStatus
    {
        GOING_UP,
        STATIC,
        GOING_DOWN
    }
}
