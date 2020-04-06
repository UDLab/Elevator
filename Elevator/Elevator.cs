using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Elevator
    {
        public int Capacity { get; set; }
    }

    public enum ElevatorStatus
    {
        GOING_UP,
        STATIC,
        GOING_DOWN
    }
}
