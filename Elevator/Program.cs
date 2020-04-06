using System;
using System.Collections.Generic;

namespace Elevator
{
    class Program
    {
        static List<int[]> input;
        static int floors = 10;

        static void Main(string[] args)
        {
            Initiate();
            FileService.PrintPath();
            Console.ReadLine();
        }

        private static void Initiate()
        {
            input = FileService.GetInput();
        }

        //private static void WriteFileTest()
        //{
        //    Console.WriteLine("Testing write..");
        //    List<Passenger> testpassengers = new List<Passenger>();
        //    int count = 0;
        //    for (int i = 0; i < input.Count; i++)
        //    {
        //        for (int j = 0; j < input[i].Length; j++)
        //        {
        //            testpassengers.Add(new Passenger(count, (i % floors), input[i][j], i/floors));
        //            count++;
        //        }
        //    }
        //    FileService.GenerateOutput(testpassengers);

        //    Console.WriteLine("Write done!");
        //    Console.WriteLine();
        //}

        //private static void ReadFileTest()
        //{
        //    input = FileService.GetInput();

        //    Console.WriteLine("file contains: ");
        //    foreach (int[] line in input)
        //    {
        //        printline(line);
        //    }
        //    Console.WriteLine();
        //}

        static void PrintArray(int[] line)
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