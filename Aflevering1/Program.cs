namespace Aflevering1; // Emil Peter Lykke Lindquist

using System.ComponentModel.Design;
using static System.Console; // Den her linje er for at man ikke behøver at skrive "Console" heletiden, så du initialisere det på hele projekted
    internal class Program
{
    // her indsætter jeg de tabeller med varePris og vareNavn. Der skal være 10 hver som opgaven siger.
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
        // her sætter jeg min metode ind
        menu();
    }

    static void menu()
    {
        // Her har jeg en bool som endten kan være true eller false. Hvis loggedInd ikke er false, er du logged ind
        if (loggedIn != false)
        {
            WriteLine("Logged in!\n");
        }

        // Her laver jeg en tabel hvor jeg har alle valg mulighedderne.
        string[] options = { "Login", "Add item", "Show list", "Order item", "Exit" };

        // Her laver jeg et forloop til at WriteLine alle ordene i min tabel
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
                // Hvis brugerens input til username er som stringen admin og (Som vises med &&) det samme password
                if (username == admin && password == adminPassword)
                {
                    // Hvis ja, har du logged ind
                    Clear();
                    Write("You logged in succesfully!");

                    // Her sætter du loggedIn til true, så du kan se du er loggede ind
                    loggedIn = true;
                } else
                {
                    // ellers det ikke passer, kan du ikke logged ind
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
                        // Jeg siger i + 1 fordi et array starter ved nul, så ved at sætte + 1 starter dit Write med 1
                        Write($"|{i + 1}|");
                    }
                }

                // Her skal brugeren inputte et id som de gerne vil ændre
                Write("\n\nPick id: ");
                id = Convert.ToInt32(ReadLine()!);
                // jeg siger id - 1 fordi at en array starter ved 0. Men vi har en tabel der går fra 1 til 10. Så det er et work around for at kunne vælge den rigtige tabel
                id--;

                Clear();

                // Her vælger du og indsætter dit vareNavn og din varePris
                if (itemPrice[id] == 0)
                {
                    Write("Item name: ");
                    string idName = Console.ReadLine()!;
    
                    Write("Item price: ");
                    int price = Convert.ToInt32(ReadLine()!);

                    // Efter brugeren har inputtet vareNavn og varePris, sætter du de variabler ind på id'ets plads
                    itemName[id] = idName;
                    itemPrice[id] = price;
                    WriteLine("Added item succesfully!");
                } else
                {
                    // Hvis du har valgt et id som ikke vises på konsolen, er den allerede ændret
                    WriteLine("Already assigned item to this id");
                } 

                // Her ryder jeg konsolen og går tilbage til start
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
                Clear();
                // Her laver jeg et for loop for at indskrive alle vareNavn og varePris
                // \n er for at gå på næste linje
                for (int i = 0; i < itemName.Length; i++)
                {
                    WriteLine($"{i + 1}: \nItem name: {itemName[i]}\nItem price: {itemPrice[i]}kr\n");
                }

                // Her får du brugeren til at vælge et vare id
                Write("Pick id to purchase: ");
                id = Convert.ToInt32(ReadLine())!;

                Clear();

                // Her er der et if statement til at tjekke om varen kan købes. Hvis varen ikke har en pris kan den ikke købes
                if (itemPrice[id - 1] > 0)
                {
                    WriteLine($"You've picked: {itemName[id - 1]}");
                } else
                {
                    // Hvis varen ikke har et id kan du ikke vælge den
                    Clear();
                    Write("Item not available");
                    ReadKey();
                    Clear();
                    menu();
                }

                // Her får du brugeren til at inputte det antal af varen de ville købe
                Write("How many would you like to purchase?: ");
                int amount = Convert.ToInt32(ReadLine()!);

                // Hvilken navn det er købt til
                Write("Who is this order assigned to?: ");
                string name = ReadLine()!;
                Clear();

                // Her siger du tak til brugeren
                Write($"Thank you for your purchase {name}");
                // Her viser du brugeren hvad de har købt. Grunden til at det er id - 1 er fordi at en array starter ved 0. Men vi har plussede det med en for at vise det pænt på konsolen
                Write($"\nYou've bought: {itemName[id - 1]}");
                // Her ganger du så din pris med det antal af varen brugeren har inputtet
                Write($"\nYour total price is: {itemPrice[id - 1] * amount}");
                // Dette er noget jeg fandt på w3schools. Det er en funktion der viser den rigtige tid på din pc
                string tid = DateTime.Now.ToLongTimeString();
                string dato = DateTime.Now.ToLongDateString();
                Write($"\nTime of purchase: ({dato})({tid})");

                ReadKey();
                Clear();
                menu();
                break;

            case "q":
                break;

            default:
                break;
        }
        
    }
}
