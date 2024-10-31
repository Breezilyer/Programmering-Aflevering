namespace Aflevering1; // Emil Peter Lykke Lindquist

using System.ComponentModel.Design;
using static System.Console; // Den her linje er for at man ikke behøver at skrive "Console" heletiden, så du initialisere det på hele projekted
    internal class Program
{
    // her indsætter jeg de tabeller med varePris og vareNavn. Der skal være 10 hver som opgave siger.
    static int[] itemPrice = new int[10];
    static string[] itemName = new string[10];
    static int id;

    // Her indsætter jeg en global admin login string, for at man kan login og indsætte vare og priser.
    static string admin = "admin";
    static string adminPassword = "secret";
    // Her laver jeg en global bool. Hvis du er loggedIn er den true, ellers ikke er den false
    static bool loggedIn = false;

    static void Main(string[] args)
    {
        menu();
    }

    static void menu()
    {
        // Her har jeg en bool som endten kan være true eller false. Hvis logged ind ikke er false, er du logged ind
        if (loggedIn != false)
        {
            WriteLine("Logged in!\n");
        }

        // Her laver jeg en tabel hvor jeg har alle valg mulighedderne.
        string[] options = { "Login", "Add item", "Show list", "Order item", "Exit" };

        // Her laver jeg et for loop til at WriteLine alle ordene i min tabel
        for (int i = 0; i < 4; i++)
        {
            WriteLine($"{i + 1}: {options[i]}");
        }
        // Her slutter jeg af med at skrive den sidste, så der kan stå "q" i stedet for et tal
        WriteLine("q: Exit");

        // Her laver jeg en ReadLine så brugeren kan input
        Write("Input: ");
        string input = Console.ReadLine()!;


        // Her laver en switch for at kunne vælge valg mulighedderne
        switch (input.ToLower()) // ToLower() er til at man endten kan skrive lille q eller stort Q
        {
            case "1":
                Clear(); // Dette ryder hele konsolen

                // Her tjekkes der om du allerede loggede ind. Hvis du er så gå tilbage til start
                if (loggedIn == true)
                {
                    WriteLine("You're already logged in!");
                    // Her ryder jeg konsolen og går tilbage til start
                    ReadKey();
                    Clear();
                    menu();
                }

                // Her laver jeg ReadLine til både Username og Password
                Write("Username: ");
                string username = Console.ReadLine()!;
                Write("Password: ");
                string password = Console.ReadLine()!;

                // Her laver jeg et if statement
                // Hvis brugerens input til username er som variablen admin og (Som vises med &&) det samme password
                if (username == admin && password == adminPassword)
                {
                    // Hvis ja, har du logged ind
                    Clear();
                    Write("You logged in succesfully!");

                    // Her sætter du loggedIn til true, så du kan se du er loggede ind
                    loggedIn = true;
                } else
                {
                    // ellers det ikke passer, har du ikke logged ind
                    Write("Username or Password does not match the login.");
                }
                // Her ryder jeg konsolen og går tilbage til start
                ReadKey();
                Clear();
                menu();
                break;

            case "2":
                Clear();

                // her bruger jeg et if statement for at tjekke om brugeren er loggede ind. Hvis loggedIn ikke er true, må du ikke tilføje vare
                if (loggedIn != true)
                {
                    WriteLine("You're not logged in!");
                    ReadKey();
                    Clear();
                    menu();
                }


                // Her for du alle de id'er du kan ændre at vide. Hvis varePris = 0 er varen ikke ændret.
                WriteLine("These are all the available items to add:\n");
                for (int i = 0; i < itemPrice.Length; i++)
                {
                    if (itemPrice[i] == 0)
                    {
                        Write($"|{i + 1}|");
                    }
                }

                // Her skal brugeren inputte et id som de gerne vil ændre
                Write("\n\nPick id: ");
                id = Convert.ToInt32(ReadLine()!);
                // jeg siger id - 1 fordi at en array starter ved 0. Men vi har en tabel der går fra 1 til 10. Så det er et work around for at kunne vælge den rigtige tabel
                id -= 1;

                Clear();

                if (itemPrice[id] == 0)
                {
                    Write("Item name: ");
                    string name = Console.ReadLine()!;
    
                    Write("Item price: ");
                    int price = Convert.ToInt32(ReadLine()!);

                    itemName[id] = name;
                    itemPrice[id] = price;
                    WriteLine("Added item succesfully!");
                } else
                {
                    WriteLine("Already assigned item to this id");
                    input = "2";
                } 

                ReadKey();
                Clear();
                menu();
                break;

            case "3":
                Clear();
                // Her laver jeg et for loop for at indskrive alle vareNavn og varePris
                // \n er for at gå på næste linje
                for (int i = 0; i < itemName.Length; i++)
                {
                    WriteLine($"{i + 1}: \nItem name: {itemName[i]}\nItem price: {itemPrice[i]}kr\n");
                }

                // her laver jeg en ReadKey() så brugen kan trykke "Enter" for at gå tilbage til start
                WriteLine("Back: Enter");
                ReadKey();
                Clear();
                menu();
                break;

            case "4":
                WriteLine($"You chose {options[3]}");
                break;

            case "q":
                WriteLine($"You chose {options[4]}");
                ReadKey();
                break;

            default:
                Clear();
                menu();
                break;
        }
        
    }
}
