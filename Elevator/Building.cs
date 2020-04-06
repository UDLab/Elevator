using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Building
    {
        public List<List<Passenger>> Floors { get; set; }
        public Elevator Elevator { get; set; }
        public Building(int nr)
        {
            Floors = new List<List<Passenger>>();
            for (int i = 0; i < nr; i++)
            {
                Floors.Add(new List<Passenger>());
            }
        }

        public void AddPassengers(List<Passenger> passengers, int nr)
        {
            foreach(Passenger p in passengers)
            {
                Floors[nr].Add(p);
            }
        }

        public void RemovePassenger(Passenger p, int nr)
        {
            Floors[nr].Remove(p);
        }
    }

    public enum FloorStatus
    {
        UP_PRESSED,
        NO_PRESSED,
        DOWN_PRESSED
    }
}
