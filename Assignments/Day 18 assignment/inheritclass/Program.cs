namespace inheritclass
{
    internal class Program
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public decimal BasicSalary { get; set; }
            public int ExperienceInYears { get; set; }
            
            public Employee(int EmployeeId, string EmployeeName, decimal BasicSalary, int ExperienceInYears)
            {

               this.EmployeeId= EmployeeId;
                this.EmployeeName = EmployeeName ;
                this.BasicSalary = BasicSalary;
               this.ExperienceInYears  = ExperienceInYears ;

                
            }
            public decimal CalculateAnnualSalary()
            {
                  decimal AnnualSalary = (decimal)(BasicSalary * 12);
                return AnnualSalary;
            }
            public string DisplayEmployeeDetails()
            {
                return $"Employee ID is :{EmployeeId}  Employee Name is :{EmployeeName}  Employee Basic salary is : {BasicSalary} Employee year of experience {ExperienceInYears} Annual salary is : {CalculateAnnualSalary()}";
            }
        }

        class PermanentEmployee:Employee
        {
            public PermanentEmployee(int id , string name , decimal salary, int years ):base(id, name ,salary, years){
                EmployeeId= id ;

                EmployeeName= name ;
                BasicSalary = salary ;
                ExperienceInYears = years ;
            }
            public decimal CalculateAnnualSalary()
            {
                decimal bonus = 0;
                if (ExperienceInYears >= 5)
                {
                    bonus = 50000;
                }
                

                    return (decimal)(((BasicSalary)+(BasicSalary * 0.2M) + (BasicSalary * 0.1M) +(bonus))*12);
            }

        }
        class ContractEmployee : Employee
        {
            public int ContractDurationInMonths{ get; set; }
            public ContractEmployee(int id, string name, decimal salary, int years,int duration) : base(id, name, salary, years)
            {
                EmployeeId = id;

                EmployeeName = name;
                BasicSalary = salary;
                ExperienceInYears= years ;
                ContractDurationInMonths = duration;
            }
            public decimal CalculateAnnualSalary()
            {
                decimal bonus = 0;
                if (ContractDurationInMonths >= 12)
                {
                    bonus = 30000;
                }


                return (decimal)(((BasicSalary)+(bonus))*12);
            }

        }
        class InternEmployee : Employee
        {
             public InternEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
            {
                EmployeeId = id;

                EmployeeName = name;
                BasicSalary = salary;
                ExperienceInYears = years;
            }
            public decimal CalculateAnnualSalary()
            {
                


                return (decimal)(BasicSalary * 12);
            }

        }
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1001,"Mayank",67833,8);
            PermanentEmployee e2 = new PermanentEmployee(1002, "AAroh", 67833, 8);
            ContractEmployee e3= new ContractEmployee(1003, "Ritik", 67833, 0,14);
            InternEmployee e4 = new InternEmployee(1004, "Sahil", 67833, 2);

            Console.WriteLine(e1.CalculateAnnualSalary());
           Console.WriteLine( e2.CalculateAnnualSalary());
            Console.WriteLine(e3.CalculateAnnualSalary());
            Console.WriteLine(e4.CalculateAnnualSalary());
            

        }
    }
}
