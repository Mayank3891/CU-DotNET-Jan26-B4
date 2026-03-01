using System.ComponentModel.Design;

namespace Annualbonus
{
     public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }

        public int PerformanceRating { get; set; }
        public int YearofExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        
        public decimal NetAnnualBonus
        {
            get
            {
                decimal y = 0;
                decimal Bonus = 0 ;
                if (BaseSalary <= 0)
                {
                    return 0;
                }
                decimal bonusp = 0;
                if (PerformanceRating == 5)
                
                    bonusp = 0.25m;
                else if (PerformanceRating == 4)

                    bonusp = 0.18m;
                else if (PerformanceRating == 3)

                    bonusp = 0.12m;
                else if (PerformanceRating == 2)

                    bonusp = 0.05m;
                else if (PerformanceRating == 1)

                    bonusp = 0;
                else
                    throw new InvalidOperationException("Invalid string ");

                Bonus = BaseSalary * bonusp;
                if (YearofExperience > 10)
                {
                    y = BaseSalary * 0.05m;
                    Bonus = y + Bonus;
                }
                else if (YearofExperience > 5)
                {
                    y = BaseSalary * 0.03m;
                    Bonus += y;
                }
                else
                {
                    Bonus += y;
                }

                

                //Attendance Penalty
                decimal k = Bonus * 0.2m;
                if (AttendancePercentage < 85)
                {
                    Bonus =Bonus- k;
                    
                }
                Bonus = Bonus * DepartmentMultiplier;
                decimal cap = BaseSalary * 0.4m;
                if (Bonus > cap)
                {
                    Bonus = cap;
                }

                decimal tax= 0;
                if (Bonus <= 150000)
                {
                    tax = Bonus * 0.1m;
                    Bonus = Bonus - tax;

                }
                else if (Bonus > 150000 && Bonus <= 300000)
                {
                    tax = Bonus * 0.2m;
                    Bonus = Bonus - tax;
                }
                else if (Bonus > 300000)
                {
                    tax = Bonus * 0.3m;
                    Bonus = Bonus - tax;
                }
                Bonus = Math.Round(Bonus, 2);
                    return Bonus;
            }
        }
        static void Main(string[] args)
        {
            EmployeeBonus emp = new EmployeeBonus();
            emp.NetAnnualBonus;
            
        }

    }
    
    
}
