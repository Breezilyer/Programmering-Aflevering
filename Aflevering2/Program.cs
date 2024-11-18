using System.ComponentModel;
using static System.Console;

namespace Aflevering2
{
    internal class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            menu(bank);
            ReadLine();
        }

        static void menu(Bank bank)
        {
            string[] options = { "Add customer: 1", "Add employee: 2", "Show everyone: 3", "Change adress: 4", "Change pay check: 5"};
            foreach (string opt in options)
            {
                WriteLine(opt);
            }
            Write("Input: ");
            string input = ReadLine()!;

            switch (input)
            {
                case "1":
                    addCustomer(bank);
                    break;
                case "2":
                    addEmployee(bank);
                    break;
                case "3":
                    showAll(bank);
                    break;
                case "4":
                    setAdress(bank);
                    break;
                case "5":
                    setPayCheck(bank);
                    break;
            }
        }
        static void addCustomer(Bank bank)
        {
            Clear();
            Write("Input name: ");
            string name = ReadLine()!;
            Write("Input adress: ");
            string adress = ReadLine()!;
            Write("Input CPR-NR (example: 123456-7890): ");
            string cprNr = ReadLine()!;

            Customer customer = new Customer(name, cprNr, adress);
            bank.Customers.Add(customer);
            WriteLine("Customer added!");
            ReadLine();
            Clear();
            menu(bank);

        }
        static void addEmployee(Bank bank)
        {
            Clear();
            Write("Input name: ");
            string name = ReadLine()!;
            Write("Input CPR-NR (example: 123456-7890): ");
            string cprNr = ReadLine()!;
            Write("Input pay check: ");
            string payCheck = ReadLine()!;

            Employee employee = new Employee(name, cprNr, payCheck);
            bank.Employees.Add(employee);
            WriteLine("Employee added!");
            ReadLine();
            Clear();
            menu(bank);
        }
        static void showAll(Bank bank)
        {
            Clear();
            WriteLine("Every customer:");
            foreach (var Customer in bank.Customers)
            {
                Customer.showInfo();
            }

            WriteLine("Every employee:");
            foreach (var Employee in bank.Employees)
            {
                Employee.showInfo();
            }
            ReadLine();
            Clear();
            menu(bank);
        }
        static void setAdress(Bank bank)
        {
            Clear();
            Write("Input customer CPR-NR: ");
            string cprnr = ReadLine()!;
            // FirstOrDefault er noget jeg fandt på her: (https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-8.0)
            var customer = bank.Customers.FirstOrDefault(customer => customer.cprNr == cprnr);
            if (customer != null)
            {
                Write("Input new adress: ");
                string input = ReadLine()!;
                customer.setAdress(input);
                WriteLine("Changed adress!");
            }
            else
            {
                WriteLine("Cannot find any CPR-NR matching your input.");
            }
            ReadLine();
            Clear();
            menu(bank);
        }
        static void setPayCheck(Bank bank)
        {

        }
    }

    public class Person
    {
        string Name { get; set; }
        public string cprNr { get; set; }

        public Person(string navn, string cprnr)
        {
            Name = navn;
            cprNr = cprnr;
        }

        public virtual void showInfo()
        {
            WriteLine($"Name: {Name} \nCPR-Nr: {cprNr}");
        }
    }

    public class Customer : Person
    {
        private string Adress { get; set; }

        public Customer(string Name, string cprNr, string adress) : base(Name, cprNr)
        {
            Adress = adress;
        }

        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Adress: {Adress}\n");
        }

        public void setAdress(string newAdress)
        {
            Adress = newAdress;
        }
    }

    public class Employee : Person
    {
        private string payCheck { get; set; }

        public Employee(string Name, string cprNr, string paycheck) : base(Name, cprNr)
        {
            payCheck = paycheck;
        }

        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Pay Check: {payCheck}\n");
        }

        public void setPayCheck(string setPaycheck)
        {
            payCheck = setPaycheck;
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
