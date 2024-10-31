namespace Aflevering1
using static System.Console; // Den her linje er for at man ikke behøver at skrive "Console" heletiden, så du initialisere det på hele projekted
{
    internal class Program
{
    // her indsætter jeg de tabeller med varePris og vareNavn. Der skal være 10 hver som opgave siger.
    static int[] itemPrice = new int[10];
    static string[] itemPrice = new string[10];

    // Her indsætter jeg admin login, for at man kan login og indsætter vare og priser.
    static string admin = "admin";
    static string password = "password";

    static void Main(string[] args)
    {

    }

    static int menu()
    {
        string[] options = { "Login", "Add item", "Show list", "Order item", "Exit" };
        for (int i = 0; i < options.Length; i++)
        {
            WriteLine($"{i + 1}: {options[i]}");
        }
    }
}
}
