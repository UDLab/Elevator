using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Elevator
{
    public class FileService
    {
        static string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        static string file = "/../sample.txt";

        public static List<int[]> GetPassengers()
        {
            List<int[]> result = new List<int[]>();

            try
            {
                string[] lines = File.ReadAllLines(path + file);
                result = ConvertToIntList(lines);
            } catch (Exception e)
            {
                Console.WriteLine("Error reading input file: " + e.Message);
            }

            return result;
        }

        private static List<int[]> ConvertToIntList(string[] lines)
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
                        Console.WriteLine("Error read values in input file: " + e.Message);
                    }
                }
                res.Add(numbers);
            }
            return res;
        }
    }
}
