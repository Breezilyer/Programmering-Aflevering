using System;
// using static System.Console; er brugt her, så der ikke behøves at skrive Console.Write, etc.
using static System.Console;
namespace Aflevering2Recap
{
    internal class Program // Emil Peter Lykke Lindquist
    {
        // Her har jeg 2 lister, som skal bruges til at holde information om "Customer", og "Employee".
        static List<Customer> Customers = new List<Customer>();
        static List<Employee> Employees = new List<Employee>();
        // Her laver jeg en bool som bruges til at se om menu'en køre. Hvis den er true, kører menu'en.
        // Hvis ikke skal den lukkes.
        static bool menuRunning = true;
        static void Main(string[] args)
        {
            // Her kalder jeg min metode menu.
            menu();
        }
        // Her har jeg lavet en menu metode, som håndtere alle de valg muligheder brugeren kan vælge.
        static void menu()
        {
            // Jeg clear() her fordi så konsolen er rydet, og ser pænt ud.
            Clear();
            // while loopet er brugt her for at kunne se, om menu'en er kørebart.
            // Imens menuRunning = true så gør det inde i tuborgklammerne.
            while (menuRunning)
            {
                // Her har jeg lavet en array som holder alle de valgmuligheder der er at vælg imellem.
                string[] options = 
                { 
                    "Add Customer: 1", 
                    "Add Employee: 2", 
                    "Show List: 3", 
                    "Change address: 4", 
                    "Change Pay Check: 5", 
                    "Exit : q" 
                };
                // Her bruger jeg en foreach loop for at kalde alle de ting der er inde i min options array.
                foreach (string option in options)
                {
                    WriteLine(option);
                }
                // Her laver jeg en ReadLine for at kunne få bruger input
                // som skal bruges senere til min switch case.
                string optionInput = ReadLine()!;
                // Her laver jeg en switch case som håndtere de valg muligheder som brugeren kan bruge.
                // Hvis optionInput = 1, skal den gå hen til min case 1.
                // Det bruges i stedet for if statements. Da det er mere håndtere bart at bruge
                // end at have en masse if statements, og skulle kigge igennem.
                switch (optionInput)
                {
                    case "1":
                        addCustomer();
                        break;
                    case "2":
                        addEmployee();
                        break;
                    case "3":
                        showList();
                        break;
                    case "4":
                        setAdress();
                        break;
                    case "5":
                        setPayCheck();
                        break;
                    case "q":
                        menuRunning = false;
                        break;
                }
            }
        }

        // Her har jeg lavet en "addCustomer" metode. Som håndtere at kunne tilføje "Customers".
        static void addCustomer()
        {
            // Clear for at ryde konsolen.
            Clear();
            // Her håndteres bruger input.
            Write("Input name: ");
            string name = ReadLine()!;
            Write("\nInput CPR-nr (Example: 000000-0000): ");
            string cpr = ReadLine()!;
            Write("\nInput adress: ");
            string adress = ReadLine()!;

            // Her kalder jeg objektet Customer. Hvor jeg har sat alle bruger inputtet ind i parameteren
            // for at initialisere dem ind.
            Customer customer = new Customer(name, cpr, adress);
            // Her bruges så bank objektet. Jeg kalder "Customers" listen
            // hvor jeg dernæst tilføjer den nye objekt "customer" ind i "Customers" listen.
            Customers.Add(customer);
            // Dette er bare for at kunne verificere at Customeren er tilføjet til listen.
            WriteLine("Customer added!");
            ReadLine();
            menu();
        }
        // Her har jeg en addEmployee metode. Den gør næsten det samme som addCustomer.
        // Men her putter jeg PayCheck ind i stedet for adresse.
        static void addEmployee()
        {
            Clear();
            Write("Input name: ");
            string name = ReadLine()!;
            Write("\nInput CPR-nr (Example: 000000-0000): ");
            string cpr = ReadLine()!;
            Write("\nInput Pay Check: ");
            string payCheck = ReadLine()!;

            Employee employee = new Employee(name, cpr, payCheck);
            Employees.Add(employee);
            WriteLine("Employee added!");
            ReadLine();
            menu();
        }
        static void showList()
        {
            Clear();
            WriteLine("All Customers:");

            // Her bruger jeg en foreach loop, for at kunne gå igennem alle de ting
            // som er inde i Customers listen.
            foreach (var customer in Customers)
            {
                // Her bruger jeg en indbygget metode som er inde i min "Customer" objekt.
                // Den forklares nede ved Person Objektet.
                customer.showInfo();
                WriteLine();
            }
            // Det samme er gjort her.
            WriteLine("All Employees:");
            foreach (var employee in Employees)
            {
                employee.showInfo();
                WriteLine();
            }
            ReadLine();
            menu();
        }

        // Her har jeg en setAdress metode. Som håndtere at kunne ændre en adresse, ved at vælge en person
        // ved at skrive deres cpr-nummer.
        static void setAdress()
        {
            Clear();
            // Her håndteres brugerinput.
            Write("Enter CPR-nr: ");
            string cpr = ReadLine()!;

            // Her bruger jeg en foreach loop, for at kunne gå igennem alle tingene
            // inde i min Customers liste.
            foreach (var customer in Customers)
            {
                // Her bruges en if statement. Hvis der er et sted i min liste
                // som er det samme som bruger inputtet.
                // Skal den gøre tingene inde i tuborgklammerne.
                if (customer.cpr == cpr)
                {
                    // Hvis et sted i listen, som er cpr-nummeret, er det samme som bruger inputtet.
                    // Skal den gør dette.
                    WriteLine("Input new Adress: ");
                    string adress = ReadLine()!;
                    // Her bruger jeg en indbygget metode inde i Customer objektet.
                    // Den forklares nede ved Customer objektet.
                    customer.setAdress(adress);
                    WriteLine("Succesfully changed adress!");
                }
                else
                {
                    // Hvis bruger inputtet ikke kunne findes, skal der skrives.
                    WriteLine("Couldn't find that person!");
                }
            }
            ReadLine();
            menu();
        }
        // Det samme er gjort her nede som setAdress. Men i stedet for at ændre adressen
        // skal den ændre Employess PayCheck.
        static void setPayCheck()
        {
            Clear();
            Write("Enter CPR-nr: ");
            string cpr = ReadLine()!;

            foreach (var employee in Employees)
            {
                if (employee.cpr == cpr)
                {
                    WriteLine("Input new Pay Check: ");
                    string payCheck = ReadLine()!;
                    employee.setPayCheck(payCheck);
                    WriteLine("Succesfully changed Pay Check!");
                }
                else
                {
                    WriteLine("Couldn't find that person!");
                }
            }
            ReadLine();
            menu();
        }
    }

    // Her har jeg en Person klasse. Dette er moder klassen, som skal håndtere navne og cpr-numre.
    public class Person
    {
        // Her har jeg lavet 2 variabler, name og cpr. De er sat til get; set;.
        // Som betyder at du kan kalde den.
        // Og du kan sætte den til noget.
        public string name { get; set; }
        public string cpr { get; set; }

        // Her laver jeg en Person objekt. Som siger, at de 2 variabler som man kan sætte og ændre
        // som er i lig med Objektets parameter.
        public Person(string name, string cpr)
        {
            // Der bruges this. for at sige at det er variablerne oppe over objektet vi har med at gøre.
            this.name = name;
            this.cpr = cpr;
        }
        // Her har jeg en showInfo metode. Den skriver navn og cpr-nummer pænt op.
        // Den er sat til at være virtual, for at du kan override den senere til at kunne ændre i den.
        public virtual void showInfo()
        {
            WriteLine($"Name: {name}\nCPR-nr: {cpr}");
        }
    }

    // Her har jeg en Customer klasse, som har arv af Person.
    // Det kan ses ved at der er : ved siden af Navnet.
    // : betyder arv.
    public class Customer : Person
    {
        public string adress { get; set; }
        // Her er customer objektet. Den arver name og cpr, ved hjælp af base.
        // Base er nu name og cpr.
        public Customer(string name, string cpr, string adress) : base(name, cpr)
        {
            this.adress = adress;
        }

        // Her har jeg også en showInfo metode.
        // Læg mærke til at den er sat til override.
        // Det betyder at du tager en allerede eksisterende metode, og ændre på den.
        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Adress: {adress}");
        }
        // Her laver jeg en setAdress metode. Den gør sådan at jeg kan kalde den
        // og sætte en ny adresse ind i parameteren.
        public void setAdress(string newAdress)
        {
            adress = newAdress;
        }
    }
    // Her har jeg en klasse som arver af Person også.
    // Den er næsten ligesom Customer klassen, men i stedet for adresse, er det payCheck.
    public class Employee : Person
    {
        public string payCheck { get; set; }
        public Employee(string name, string cpr, string payCheck) : base(name, cpr)
        {
            this.payCheck = payCheck;
        }
        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Pay Check: {payCheck}kr");
        }
        public void setPayCheck(string newPayCheck)
        {
            payCheck = newPayCheck;
        }
    }
}