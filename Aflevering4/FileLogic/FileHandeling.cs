using Aflevering4.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aflevering4.FileHandeling
{
    internal class FileHandeling
    {
        private static string path = @"CreateFile.txt";

        public static void CreateCustomer(Kunde k)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{k.tlfnr},{k.navn},{k.adresse}");
            sw.Close();
        }
    }
}
