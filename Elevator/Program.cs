using System;
using System.Collections.Generic;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            List<int[]> passengers = FileService.GetPassengers();

            Console.WriteLine("file contains: ");

            foreach (int[] line in passengers)
            {
                printline(line);
            }

            Console.WriteLine();
            Console.WriteLine("Press ANYTHING to exit...");
            Console.ReadLine();
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