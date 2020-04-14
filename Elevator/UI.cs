using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Elevator
{
    class UI
    {
        public static void Print(Building building)
        {
            Thread.Sleep(10);
            Console.Clear();
            for (int i = building.Floors.Count - 1; i >= 0; i--)
            {
                Console.Write("[FLOOR {0}] : ", i);
                if (building.ElevatorAtFloor == i)
                {
                    building.Elevator.Print();
                }
                else
                {
                    Console.Write("     ");
                }
                building.Floors[i].Print();
                Console.WriteLine();
            }
        }

        public static void Summarize(List<Passenger> completedPassengers)
        {
            Console.Clear();
            double avgWaiting = completedPassengers.Average(x => x.waitingTime);
            double avgSystem = completedPassengers.Average(x => x.systemTime);
            double avgComplete = completedPassengers.Average(x => x.completionTime);

            Console.WriteLine("Done!\n");
            Console.WriteLine("Average waiting time:\t\t" + Math.Round(avgWaiting, 2) + " units");
            Console.WriteLine("Average system time:\t\t" + Math.Round(avgSystem, 2) + " units");
            Console.WriteLine("Average completion time:\t" + Math.Round(avgComplete, 2) + " units");
        }
    }
}
