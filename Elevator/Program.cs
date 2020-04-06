using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Elevator
{
    class Program
    {
        static int time = 0;
        static Building building;
        static List<int[]> input;
        static List<Passenger> completed = new List<Passenger>();

        static void Main(string[] args)
        {
            Initiate();
            Start();
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        /// <summary>
        /// Initializes input data from file and creates building with elevator. Reads once from input to get into while loop in "Start()".
        /// </summary>
        private static void Initiate()
        {
            input = FileService.GetInput();
            building = new Building(10, 10);
            AddNewPassengersToQueue();
            Print();
        }

        /// <summary>
        /// Main loop. Adds time -> Reads input file for new passengers -> Operates elevator.
        /// </summary>
        private static void Start()
        {
            while (building.HasWaitingPassengers() || building.Elevator.Riders.Count > 0)
            {
                time += 10;
                AddNewPassengersToQueue();
                DisembarkPassengers(building.Elevator.AtFloor);
                EmbarkPassengers(building.Elevator.AtFloor);
                MoveElevator();
                Print();
            }
            FileService.GenerateOutput(completed);
        }

        private static void Print()
        {
            Thread.Sleep(50);
            Console.Clear();
            for (int i = building.Floors.Count -1 ; i > 0; i--)
            {
                Console.Write("[FLOOR {0}] : ", i);
                if (building.Elevator.AtFloor == i)
                {
                    building.Elevator.Print();
                } else
                {
                    Console.Write("     ");
                }
                building.Floors[i].Print();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Takes (and removes) "NrOfFloor" inputs from the input list and adds them to the corresponding floor queues.
        /// </summary>
        private static void AddNewPassengersToQueue()
        {
            if (input.Count == 0) return;
            List<int[]> current = input.Take(building.NrOfFloors).ToList();
            input.RemoveRange(0, 10);
            for (int i = 0; i < current.Count; i++)
            {
                List<Passenger> PassengersAtFloor = new List<Passenger>();
                foreach(int destination in current[i])
                {
                    PassengersAtFloor.Add(new Passenger(i, destination, time));
                }
                building.AddPassengersToQueue(PassengersAtFloor, i);
            }
        }

        /// <summary>
        /// If any passengers are waiting on the current floor and the elevator has room, add them to elevator passenger list and remove from queue.
        /// </summary>
        /// <param name="floor"></param>
        private static void EmbarkPassengers(int floor)
        {
            Passenger[] copy = new Passenger[building.Floors[floor].Queue.Count];
            building.Floors[floor].Queue.CopyTo(copy);
            foreach (Passenger p in copy)
            {
                if (building.Elevator.GoingCorrectDirection(p) && building.Elevator.HasRoom())
                {
                    building.Elevator.Riders.Add(p);
                    p.AddEnteringTime(time);
                    building.Floors[floor].Remove(p);
                }
            }
        }

        /// <summary>
        /// If any passenger has the current floor as destination they disembark. Documenting times into "res" variable.
        /// </summary>
        /// <param name="floor"></param>
        private static void DisembarkPassengers(int floor)
        {
            Passenger[] copy = new Passenger[building.Elevator.Riders.Count];
            building.Elevator.Riders.CopyTo(copy);
            foreach (Passenger p in copy)
            {
                if(building.Elevator.AtFloor == p.GetDestination())
                {
                    building.Elevator.Riders.Remove(p);
                    p.AddLeavingTime(time);
                    completed.Add(p);
                    p.Print();
                }
            }
        }

        /// <summary>
        /// Moves elevator, switches direction if bottom or top floor is reached.
        /// </summary>
        private static void MoveElevator()
        {  
            switch (building.Elevator.Status)
            {
                case ElevatorStatus.GOING_UP:
                    if(building.Elevator.AtFloor + 1 < building.NrOfFloors)
                    {
                        building.Elevator.Move(1);
                    } else
                    {
                        building.Elevator.Status = ElevatorStatus.GOING_DOWN;
                        building.Elevator.Move(-1);
                    }
                    break;
                case ElevatorStatus.GOING_DOWN:
                    if (building.Elevator.AtFloor > 0)
                    {
                        building.Elevator.Move(-1);
                    }
                    else
                    {
                        building.Elevator.Status = ElevatorStatus.GOING_UP;
                        building.Elevator.Move(1);
                    }
                    break;
            }
        }
    }
}