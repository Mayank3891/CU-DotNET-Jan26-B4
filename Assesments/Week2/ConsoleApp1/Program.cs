namespace ConsoleApp1
{
    internal class Program
    {
        static string kl(decimal annualPremiums) { 
        string categories = "" ;
            
                if (annualPremiums<10000)
                {
                    categories = "LOW";
                }
                else if(annualPremiums>10000 && annualPremiums < 25000)
                {
                    categories = "Medium";
                }
                else if (annualPremiums > 25000)
{
                    categories = "HIGH";
                }
            
            return categories;
                }
        
        static void Main(string[] args)
        {
            const int numberOfPolicyHolders = 5;

            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums= new decimal[5];
            for (int i = 0; i < numberOfPolicyHolders; i++)
            {
                
                string name;
                do
                {
                    Console.Write($"Enter name for policyholder {i + 1}: ");
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name));
                policyHolderNames[i] = name;

               
                decimal premium;
                do
                {
                    Console.Write($"Enter annual premium for {name}: ");
                    string input = Console.ReadLine();
                    if (!decimal.TryParse(input, out premium) || premium <= 0)
                    {
                        Console.WriteLine("Invalid premium. Must be a positive number.");
                        premium = -1;
                    }
                } while (premium <= 0);
                annualPremiums[i] = premium;
            }
            decimal total = 0;
            decimal max = annualPremiums[0];
            decimal min = annualPremiums[0];
            for (int j = 0; j < numberOfPolicyHolders; j++) {
                 total= total +annualPremiums[j];
                
                    }
            for(int l=1; l < numberOfPolicyHolders-1; l++)
            {
                if (max < annualPremiums[l])
                {
                    max = annualPremiums[l];
                }
                if (min > annualPremiums[l])
                {
                    min= annualPremiums[l];
                }
            }
            decimal average = total / numberOfPolicyHolders;
            string[] categories = new string[numberOfPolicyHolders];
            for (int j = 0;j < numberOfPolicyHolders;j++)
            {
                categories[j] = kl(annualPremiums[j]);
            }
            Console.WriteLine("    Name       annual premium      categories");

            for (int o=0; o < numberOfPolicyHolders; o++)
            { 
                Console.Write($"{policyHolderNames[o].ToUpper(),12}{annualPremiums[o],12}{categories[o],12}");
                Console.WriteLine();
            }
             Console.WriteLine($"total premium is :{total:F2}");
            Console.WriteLine($"Average Premium  :{average:F2}");
            Console.WriteLine($"Highest Premium  :{max:F2}");
            Console.WriteLine($"Lowest Premium   :{min:F2}");


        }
    }
}
