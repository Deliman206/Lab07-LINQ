using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using Lab07LINQ.Classes;

namespace Lab07LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Convert JSON to string
            string jsonFile = ReadFile(@"~/../../../../data.json");
            // Create Objects from JSON string to create Collection
            RootObject locations = JsonConvert.DeserializeObject<RootObject>(jsonFile);

            //LINQ Query
            Console.WriteLine("Output all of the neighborhoods in this data list");
            IEnumerable<string> allNames = AllNeighborhoods(locations);
            foreach (string location in allNames)
            {
                Console.Write($"{location},\n");
            }
            Console.WriteLine("========================================");

            Console.WriteLine("Filter out all the neighborhoods that do not have any names");
            IEnumerable<string> allNamesNoBlanks = AllNeighborhoodsWithNames(allNames);
            foreach (string location in allNamesNoBlanks)
            {
                Console.Write($"{location},\n");
            }
            Console.WriteLine("========================================");

            Console.WriteLine("Remove the Duplicates");
            IEnumerable<string> allNamesNoDupes = allNamesNoBlanks.Distinct();
            foreach (string location in allNamesNoDupes)
            {
                Console.Write($"{location},\n");
            }
            Console.WriteLine("========================================");

            Console.WriteLine("Rewrite the queries from above, and consolidate all into one single query.");
            IEnumerable<string> neighborhoodsNoDupes = locations.features.Select(x => x.properties.neighborhood).Where(n => n != "").Distinct();
            foreach (string location in neighborhoodsNoDupes)
            {
                Console.Write($"{location},\n");
            }
            Console.WriteLine("========================================");

            Console.WriteLine("Rewrite at least one of these questions only using the opposing method(example: Use LINQ instead of a Lambda and vice versa.");
            IEnumerable<string> AllNeighborhoodsWithNamesAGAIN = allNames.Where(n => n != "");
            foreach (string location in AllNeighborhoodsWithNamesAGAIN)
            {
                Console.Write($"{location},\n");
            }
            Console.WriteLine("\n\n");
            Console.Read();
        }
        /// <summary>
        /// Method to read our JSON file and convert to StreamReader
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            string x;
            using (StreamReader sr = new StreamReader(path))
            {
                x = sr.ReadToEnd();
            }
            return x;
        }
        /// <summary>
        /// Method to query the JSON for all locations based on based on the property neighborhood
        /// </summary>
        /// <param name="locations"></param>
        /// <returns>Enumerable List</returns>
        public static IEnumerable<string> AllNeighborhoods(RootObject locations)
        {
            var queryAllNeighborhoods =
                from location in locations.features
                select location.properties.neighborhood;
           return queryAllNeighborhoods;
        }
        /// <summary>
        /// Method to query the JSON for all neighbors except those with neighborhood = ""
        /// </summary>
        /// <param name="locations">Enumerable List</param>
        /// <returns>Enumerable List</returns>
        public static IEnumerable<string> AllNeighborhoodsWithNames(IEnumerable<string> locations)
        {
            var queryAllNeighborhoods =
                from location in locations
                where location != ""
                select location;

            return queryAllNeighborhoods;
        }
        /// <summary>
        /// Method to create a new StreamWriter
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path);

        }
        /// <summary>
        /// Method to update a StreamWriter
        /// </summary>
        /// <param name="path"></param>
        /// <param name="word"></param>
        public static void UpdateFile(string path, string word)
        {
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(word);
            }
        }
    }
}
