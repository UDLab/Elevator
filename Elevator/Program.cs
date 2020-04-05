using System;
using System.Collections.Generic;

namespace Elevator
{
    class Program
    {
        static List<int[]> passengers;
        static int floors = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            ReadFileTest();
            WriteFileTest();
            Console.WriteLine("Press ANYTHING to exit...");
            Console.ReadLine();
        }

        private static void WriteFileTest()
        {
            Console.WriteLine("Testing write..");
            List<Passenger> testpassengers = new List<Passenger>();
            int count = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].Length; j++)
                {
                    testpassengers.Add(new Passenger(count, (i % floors), passengers[i][j], i/floors));
                    count++;
                }
            }
            FileService.GenerateOutput(testpassengers);

            Console.WriteLine("Write done!");
            Console.WriteLine();
        }

        private static void ReadFileTest()
        {
            passengers = FileService.GetPassengers();

            Console.WriteLine("file contains: ");
            foreach (int[] line in passengers)
            {
                printline(line);
            }
            Console.WriteLine();
        }

        static void printline(int[] line)
        {
            for (int i = 0; i < line.Length - 1; i++)
            {
                Console.Write(line[i] + ", ");
            }
            Console.Write(line[line.Length-1]);
            Console.WriteLine();
        }
    }
}