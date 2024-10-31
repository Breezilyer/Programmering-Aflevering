﻿namespace Aflevering1;

using System.ComponentModel.Design;
using static System.Console; // Den her linje er for at man ikke behøver at skrive "Console" heletiden, så du initialisere det på hele projekted
    internal class Program
{
    // her indsætter jeg de tabeller med varePris og vareNavn. Der skal være 10 hver som opgave siger.
    static int[] itemPrice = new int[10];
    static string[] itemName = new string[10];

    // Her indsætter jeg admin login, for at man kan login og indsætte vare og priser.
    static string admin = "admin";
    static string adminPassword = "password";

    static void Main(string[] args)
    {
        menu();
        ReadKey();
    }

    static void menu()
    {
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
                } else
                {
                    // ellers det ikke passer, har du ikke logged ind
                    Write("Username or Password does not match the login.");
                }
                break;

            case "2":
                WriteLine($"You chose {options[1]}");
                break;

            case "3":
                WriteLine($"You chose {options[2]}");
                break;

            case "4":
                WriteLine($"You chose {options[3]}");
                break;

            case "q":
                WriteLine($"You chose {options[4]}");
                break;
        }
        
    }
}
