using Aflevering4.Logic;
using System.Text;

namespace Aflevering4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // CreateButton
        {
            string tlfnr = tlfnrBox.Text;
            string navn = navnBox.Text;
            string adresse = adresseBox.Text;

            Kunde k = new Kunde(tlfnr, navn, adresse);
            k.Create();
            MessageBox.Show("Customer Added!");
            tlfnrBox.Text = "";
            navnBox.Text = "";
            adresseBox.Text = "";
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
