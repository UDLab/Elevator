using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Elevator
{
    class Program
    {
        private static int floors;
        private static int capacity;

        static void Main(string[] args)
        {
            ReadUserInput();
            Simulation s = new Simulation();
            s.Initiate(floors, capacity);
            s.Start();
            Console.ReadLine();
        }

        private static void ReadUserInput()
        {
            Console.WriteLine("How many floors?");
            while (!Int32.TryParse(Console.ReadLine(), out floors))
            {
                Console.WriteLine("Please write a number");
            }
            Console.WriteLine("Elevator capacity?");
            while (!Int32.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine("Please write a number");
            }
        }
    }
}