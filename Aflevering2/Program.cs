using static System.Console;
namespace BankProject
{
    static bool menuRunning = true;
    internal class Program
    {
        static void Main(string[] args) // Emil Peter Lykke Lindquist
        {
            Bank bank = new Bank();
            menu(bank);
        }

        static void menu(Bank bank)
        {
            while (menuRunning)
            {
                string[] options = { "Add Customer: 1", "Add Employee: 2", "Show List: 3", "Change address: 4", "Change Pay Check: 5", "Exit : q" };
                foreach (string option in options)
                {
                    WriteLine(option);
                }
                string opt = ReadLine()!;
                switch (opt)
                {
                    case "1":
                        addCustomer(bank);
                        break;
                    case "2":
                        addEmployee(bank);
                        break;
                    case "3":
                        showList(bank);
                        break;
                    case "4":
                        setAdress(bank);
                        break;
                    case "5":
                        setPayCheck(bank);
                        break;
                    case "q":
                        menuRunning = false;
                        break;
                }
            }
        }
        static void addCustomer(Bank bank)
        {
            Clear();
            Write("Input name: ");
            string name = ReadLine()!;
            Write("Input CPR-NR: ");
            string cprnr = ReadLine()!;
            Write("Input address: ");
            string address = ReadLine()!;

            Customer customer = new Customer(name, cprnr, address);
            bank.Customers.Add(customer);
            WriteLine("Added Customer!");
            ReadLine();
            Clear();
            menu(bank);
        }
        static void addEmployee(Bank bank)
        {
            Clear();

            Write("Input name: ");
            string name = ReadLine()!;
            Write("Input CPR-NR: ");
            string cprnr = ReadLine()!;
            Write("Input Pay Check: ");
            string pCheck = ReadLine()!;

            Employee employee = new Employee(name, cprnr, pCheck);
            bank.Employees.Add(employee);
            WriteLine("Added Employee!");

            ReadLine();
            Clear();
            menu(bank);
        }
        static void showList(Bank bank)
        {
            Clear();

            WriteLine("Every Customer:\n");
            foreach (var customer in bank.Customers)
            {
                customer.showInfo();
            }

            WriteLine("\nEvery Employee:\n");
            foreach (var employee in bank.Employees)
            {
                employee.showInfo();
            }
            ReadLine();
            Clear();
            menu(bank);
        }
        static void setAdress(Bank bank)
        {
            Clear();
            Write("Input which CPR-NR to change address: ");
            string cprnr = ReadLine()!;

            var address = bank.Customers.FirstOrDefault(customer => customer.cprNr == cprnr);

            if (address != null)
            {
                Write("Input new address: ");
                string newAddress = ReadLine()!;
                address.setAdress(newAddress);
                WriteLine("Succefully changed address");
            }
            else
            {
                WriteLine("Could not find matching CPR-NR");
            }
            ReadLine();
            Clear();
            menu(bank);
        }
        static void setPayCheck(Bank bank)
        {
            Clear();

            Write("Input which CPR-NR to change address: ");
            string cprnr = ReadLine()!;

            var pcheck = bank.Employees.FirstOrDefault(employee => employee.cprNr == cprnr);

            if (pcheck != null)
            {
                Write("Input new Pay Check: ");
                string newPCheck = ReadLine()!;
                pcheck.setPaycheck(newPCheck);
                WriteLine("Succesfully changed Pay Check");
            }
            else
            {
                WriteLine("Could not find matching CPR-NR");
            }
            ReadLine();
            Clear();
            menu(bank);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string cprNr { get; set; }
        public Person(string name, string cprnr)
        {
            Name = name;
            cprNr = cprnr;
        }
        public virtual void showInfo()
        {
            WriteLine($"Name: {Name} \nCPR-NR: {cprNr}");
        }
    }
    public class Customer : Person
    {
        public string Adress { get; set; }
        public Customer(string name, string cprnr, string adress) : base(name, cprnr)
        {
            Adress = adress;
        }
        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Adress: {Adress}");
        }
        public void setAdress(string newAdress)
        {
            Adress = newAdress;
        }
    }
    public class Employee : Person
    {
        public string pCheck { get; set; }

        public Employee(string name, string cprnr, string pcheck) : base(name, cprnr)
        {
            pCheck = pcheck;
        }
        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Pay check: {pCheck}");
        }
        public void setPaycheck(string newPayCheck)
        {
            pCheck = newPayCheck;
        }

    }
    public class Bank
    {
        public List<Customer> Customers;
        public List<Employee> Employees;

        public Bank()
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>();
        }
    }
}
