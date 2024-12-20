using System;
using System.IO;
using static System.Console;
namespace Aflevering3
{
    internal class Program // Emil Peter Lykke Lindquist
    {
        static string path = @"Persons.csv";
        static string femalePath = @"POI-Female.csv";
        static string otherPath = @"POI-Other.csv";
        static string personsSortedPath = @"PersonsSorted.csv";
        static void Main(string[] args)
        {
            WriteLine("Persons.csv:\n-----------------------------------");
            personDotCSV();
            WriteLine("\nPOI-Female.csv:\n-----------------------------------"); 
            femaleDotCSV();
            WriteLine("\nPOI-Other.csv:\n-----------------------------------");
            otherDotCSV();
            WriteLine("\nPersonsSorted.csv:\n-----------------------------------");
            personsSortedDotCSV();
            ReadLine();
        }

        static void personDotCSV()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()!) != null)
                {
                    WriteLine(s);
                }
            }
        }


        static void femaleDotCSV()
        {
            if (!File.Exists(femalePath))
            {
                StreamWriter sw = File.CreateText(femalePath);
                sw.Close();
            }

            using (StreamReader sr = File.OpenText(path))
            {
                using (StreamWriter sw = File.CreateText(femalePath))
                {
                    string s;
                    while ((s = sr.ReadLine()!) != null)
                    {
                        string[] subs = s.Split(',');
                        if (subs[4] == "Female")
                        {
                            sw.WriteLine(s);
                            WriteLine(s);
                        }
                    }
                }
            }
            
        }

        static void otherDotCSV()
        {
            if (!File.Exists(otherPath))
            {
                StreamWriter sw = File.CreateText(otherPath);
                sw.Close();
            }

            using (StreamReader sr = File.OpenText(path))
            {
                using (StreamWriter sw = File.CreateText(otherPath))
                {
                    string s;
                    while ((s = sr.ReadLine()!) != null)
                    {
                        string[] subs = s.Split(',');
                        if (subs[4] != "Female")
                        {
                            sw.WriteLine(s);
                            WriteLine(s);
                        }
                    }
                }
            }
        }
        static void personsSortedDotCSV()
        {
            if (!File.Exists(personsSortedPath))
            {
                StreamWriter sw = File.CreateText(personsSortedPath);
                sw.Close();
            }

            string fPath = File.ReadAllText(femalePath);

            using (StreamWriter sw = File.CreateText(personsSortedPath))
            {
                sw.WriteLine(fPath);
                WriteLine(fPath);
            }

            string oPath = File.ReadAllText(otherPath);

            using (StreamWriter sw = File.AppendText(personsSortedPath))
            {
                sw.WriteLine(oPath);
                WriteLine(oPath);
            }
        }
    }
}
