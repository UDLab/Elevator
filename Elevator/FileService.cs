using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Elevator
{
    public class FileService
    {
        // Paths to files placed in the same folder as the rest of the class files.
        static string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        static string file = "/../sample.txt";

        /// <summary>
        /// Reads content from file and converts it to a list of int arrays. 
        /// </summary>
        /// <returns></returns>
        public static List<int[]> GetInput()
        {
            List<int[]> result = new List<int[]>();

            try
            {
                string[] lines = File.ReadAllLines(path + file);
                result = ConvertToIntArrayList(lines);
            } catch (Exception e)
            {
                Console.WriteLine("Error reading input file: " + e.Message);
            }

            return result;
        }

        /// <summary>
        /// Generates a file displaying times for each served elevator-rider.
        /// </summary>
        /// <param name="passengers"></param>
        public static void GenerateOutput(List<Passenger> passengers)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(path + "/../result.txt"))
                {
                    foreach(Passenger p in passengers)
                    {
                        writer.WriteLine(p.Print());
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error writing result to file: " + e.Message);
            }
        }

        public static void PrintPath()
        {
            Console.WriteLine(path);
            Console.WriteLine(file);
        }

        /// <summary>
        /// separates each line and puts the values in an int array. Catches exception if any values can't be converted.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private static List<int[]> ConvertToIntArrayList(string[] lines)
        {
            List<int[]> res = new List<int[]>();
            foreach(string line in lines)
            {
                string[] separated = line.Split(",");
                int[] numbers = new int[separated.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    try
                    {
                        numbers[i] = Int32.Parse(separated[i]);
                    } catch (Exception e)
                    {
                        Console.WriteLine("Error reading values in input file: " + e.Message);
                    }
                }
                res.Add(numbers);
            }
            return res;
        }
    }
}
