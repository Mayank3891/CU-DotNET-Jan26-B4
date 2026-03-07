namespace WeeklySalesAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal sum = 0;

            decimal maxArr = 0, minArr = decimal.MaxValue;
            decimal minIdx = 0, maxIdx = 0;

            decimal[] arr = new decimal[7];

            string[] category = new string[7];
            string[] options = { "Low", "Medium", "High" };

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1} = ");
                decimal temp = decimal.Parse(Console.ReadLine());
                if (temp < 0)
                {
                    Console.WriteLine("Sales can't be negative. Reinput ");
                    i--;
                    continue;
                }
                else
                {
                    arr[i] = temp;
                    sum += temp;

                    if (temp > maxArr)
                    {
                        maxArr = temp;
                        maxIdx = i;
                    }
                    if (temp < minArr)
                    {
                        minArr = temp;
                        minIdx = i;
                    }
                }

                if (temp <= 5000) category[i] = options[0];
                else if (temp > 5000 && temp < 15000) category[i] = options[1];
                else if (temp >= 15000) category[i] = options[2];
            }

            decimal avg = sum / 7;

            int countDays = 0;
            for (int i = 0; i < 7; i++) if (arr[i] > avg) countDays++;

            Console.WriteLine();
            Console.WriteLine($"Total Sales {":",9} {sum}");
            Console.WriteLine($"Average Daily Sales {":"} {avg:F4}");
            Console.WriteLine($"Highest Sale {":",8} {maxArr} (Day{maxIdx + 1})");
            Console.WriteLine($"Lowest Sale {":",9} {minArr} (Day{minIdx + 1})");
            Console.WriteLine();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1} : {category[i]}");
            }
        }
    }
}