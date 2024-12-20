using System;
using System.IO;
using static System.Console;
namespace Aflevering3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Person.csv:\n-----------------------------------");
            personDotcsv();
            WriteLine("POI-Female.csv:\n-----------------------------------");
            POIFemaleDotcsv();
            WriteLine("POI-Other.csv:\n-----------------------------------");
            ReadLine();
        }

        static void personDotcsv()
        {
            string path = @"Persons.csv";
            StreamReader sr = File.OpenText(path);

            string s;
            while ((s = sr.ReadLine()!) != null)
            {
                WriteLine(s);
            }

            sr.Close();
        }

        static void POIFemaleDotcsv()
        {
            string POIpath = @"POI-Female.csv";
            string personPath = @"Persons.csv";
            if (!File.Exists(POIpath))
            {
                StreamWriter sw = File.CreateText(POIpath);
                StreamReader sr = File.OpenText(personPath);
                string s;
                while ((s = sr.ReadLine()!) != null)
                {
                    string[] subs = s.Split(',');
                    if (subs[4] == "Female")
                    {
                        sw.WriteLine(s);
                    }
                }
                sr.Close();
            }
        }
    }
}
