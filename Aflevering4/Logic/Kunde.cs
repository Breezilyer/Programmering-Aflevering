using Aflevering4.FileHandeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aflevering4.Logic
{
    internal class Kunde
    {
        public string tlfnr, navn, adresse;
        public Kunde(string tlfnr, string navn, string adresse)
        {
            this.tlfnr = tlfnr;
            this.navn = navn;
            this.adresse = adresse;
        }

        public void Create()
        {
            FileHandeling.FileHandeling.CreateCustomer(this);
        }
    }
}
