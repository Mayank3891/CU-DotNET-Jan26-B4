namespace ConsoleApp1
{
    internal class Program
    {
        public class Patient
        {
            public string Name { get; set; }
            public decimal Basefee { get; set; }
            public Patient(string name, decimal basefee)
            {
                Name = name;
                Basefee = basefee;
            }
            public virtual decimal CalculateFinalBill()
            {
                return Basefee;
            }
        }
        public class Inpatient : Patient
        {
            public int Daystayed { get; set; }
            public decimal Dailyrate { get; set; }

            public Inpatient(int daystayed, decimal dailyrate, string name, decimal basefee) : base(name, basefee)
            {
                Daystayed = daystayed;
                Dailyrate = dailyrate;
            }
            public override decimal CalculateFinalBill()
            {
                decimal total = Basefee + (Daystayed * Dailyrate);
                return total;
            }

        }
        public class Outpatient : Patient
        {
            public decimal Procedurefee { get; set; }


            public Outpatient(decimal procedurefee, string name, decimal basefee) : base(name, basefee)
            {
                Procedurefee = procedurefee;
            }
            public override decimal CalculateFinalBill()
            {
                decimal total = Basefee + Procedurefee;
                return total;
            }

        }
        public class Emergencypatient : Patient
        {
            public int SecurityLevel { get; set; }


            public Emergencypatient(int securitylevel, string name, decimal basefee) : base(name, basefee)
            {
                SecurityLevel = securitylevel;
            }
            public override decimal CalculateFinalBill()
            {
                decimal total = Basefee * SecurityLevel;
                return total;
            }
        }
            class Hospitalbilling
            { 
                private List<Patient> patients = new List<Patient>();
                public void Addpatient(Patient p)
                {
                    patients.Add(p);
                }
                public void Generatedailyreport()
                {
                    Console.WriteLine("Report of patients");
                    foreach (var patient in patients)
                    {
                        decimal bill = patient.CalculateFinalBill();
                        Console.WriteLine($"{patient.Name}   :  {bill:C2}  ");
                    }

                }
                public decimal Calculatetotalrevenue()
                {
                    decimal total = 0;
                    
                    foreach (var patient in patients)
                    {
                        total += patient.CalculateFinalBill();
                    }
                    return total;
                }
                public decimal GetInpatientCount()
                {
                    decimal count = 0;
                    foreach (var patient in patients)
                    {
                        if (patient is Inpatient)
                        {
                            count++;
                        }
                    }
                    return count;

                }

            }
            static void Main(string[] args)
            {
                Hospitalbilling bil=new Hospitalbilling();
                bil.Addpatient(new Inpatient(30, 600, "naman", 6000));
                bil.Addpatient(new Outpatient( 600, "manoj", 6000));
                bil.Addpatient(new Inpatient(2, 600, "parveen", 6000));
                bil.Addpatient(new Emergencypatient(3, "sahil", 6000));

                bil.Generatedailyreport();

                Console.WriteLine($"Total revenue is:{bil.Calculatetotalrevenue()}");
                Console.WriteLine($"Total Inpatient count is:{bil.GetInpatientCount()}");
            }
        }
    }

