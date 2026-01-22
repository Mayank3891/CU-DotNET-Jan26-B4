namespace EmployeeName
{
    internal class Employees
    {
        private int id = 1000;
        public string Name { get; set; }

        private string department;

        string[] validDepartment = { "Accounts", "Sales" };
        public string Department
        {
            get { return department; }
            set { if (Array.IndexOf(validDepartment, value) > -1) department = value; }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { if (value >= 50000 && value <= 90000) salary = value; }
        }

        public void Display()
        {
            Console.WriteLine($"{id} {Name} {Department} {Salary}");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees();
            employees.Name = "Mayank";
            employees.Department = "Accounts";
            employees.Salary = 56000;

            employees.Display();
        }
    }
}