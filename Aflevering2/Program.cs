using System;
using static System.Console;
namespace Aflevering2Recap
{
    internal class Program
    {
        static bool menuRunning = true;
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            Customer customer = new Customer("Emil", "090705-5779", "Alleen 6, 6000");
            bank.Customers.Add(customer);

            Employee employee = new Employee("Bjørn", "123456-7890", "32.000");
            bank.Employees.Add(employee);
            menu(bank);
        }

        static void menu(Bank bank)
        {
            Clear();
            while (menuRunning)
            {
                string[] options = { "Add Customer: 1", "Add Employee: 2", "Show List: 3", "Change address: 4", "Change Pay Check: 5", "Exit : q" };
                foreach (string option in options)
                {
                    WriteLine(option);
                }

                string optionInput = ReadLine()!;

                switch (optionInput)
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
            Write("\nInput CPR-nr (Example: 000000-0000): ");
            string cpr = ReadLine()!;
            Write("\nInput adress: ");
            string adress = ReadLine()!;

            Customer customer = new Customer(name, cpr, adress);
            bank.Customers.Add(customer);
            WriteLine("Customer added!");
            ReadLine();
            menu(bank);
        }
        static void addEmployee(Bank bank)
        {
            Clear();
            Write("Input name: ");
            string name = ReadLine()!;
            Write("\nInput CPR-nr (Example: 000000-0000): ");
            string cpr = ReadLine()!;
            Write("\nInput Pay Check: ");
            string payCheck = ReadLine()!;

            Employee employee = new Employee(name, cpr, payCheck);
            bank.Employees.Add(employee);
            WriteLine("Employee added!");
            ReadLine();
            menu(bank);
        }
        static void showList(Bank bank)
        {
            Clear();
            WriteLine("All Customers:");
            foreach (var customer in bank.Customers)
            {
                customer.showInfo();
                WriteLine();
            }

            WriteLine("All Employees:");
            foreach (var employee in bank.Employees)
            {
                employee.showInfo();
                WriteLine();
            }
            ReadLine();
            menu(bank);
        }

        static void setAdress(Bank bank)
        {
            Clear();
            Write("Enter CPR-nr: ");
            string cpr = ReadLine()!;

            foreach (var customer in bank.Customers)
            {
                if (customer.cpr == cpr)
                {
                    WriteLine("Input new Adress: ");
                    string adress = ReadLine()!;
                    customer.setAdress(adress);
                    WriteLine("Succesfully changed adress!");
                }
                else
                {
                    WriteLine("Couldn't find that person!");
                }
            }
            ReadLine();
            menu(bank);
        }
        static void setPayCheck(Bank bank)
        {
            Clear();
            Write("Enter CPR-nr: ");
            string cpr = ReadLine()!;

            foreach (var employee in bank.Employees)
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
            menu(bank);
        }
    }

    public class Person
    {
        public string name { get; set; }
        public string cpr { get; set; }
        public Person(string name, string cpr)
        {
            this.name = name;
            this.cpr = cpr;
        }
        public virtual void showInfo()
        {
            WriteLine($"Name: {name}\nCPR-nr: {cpr}");
        }
    }

    public class Customer : Person
    {
        public string adress { get; set; }
        public Customer(string name, string cpr, string adress) : base(name, cpr)
        {
            this.adress = adress;
        }

        public override void showInfo()
        {
            base.showInfo();
            WriteLine($"Adress: {adress}");
        }

        public void setAdress(string newAdress)
        {
            adress = newAdress;
        }
    }

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
