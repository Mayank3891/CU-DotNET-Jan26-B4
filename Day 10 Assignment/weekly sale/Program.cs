namespace SalesOrderProcessing
{
    internal class Program
    {
        static bool Validate(decimal num)
        {
            return (num > 0);
        }

        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                Console.Write($"Day {i + 1} sales = ");
                decimal temp = decimal.Parse(Console.ReadLine());
                if (Validate(temp)) sales[i] = temp;
                else i--;
            }
        }

        static decimal CalculateTotal(decimal[] sales, int i)
        {
            if (i >= sales.Length) return 0;
            return sales[i] + CalculateTotal(sales, i + 1);
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal maxSale = sales.Max();
            day = Array.IndexOf(sales, maxSale);
            return maxSale;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal minSale = sales.Min();
            day = Array.IndexOf(sales, minSale);
            return minSale;
        }

        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000) return 0.10M;
            else return 0.05M;
        }
        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            if (isFestivalWeek) return (CalculateDiscount(total) + 0.05M) * total;
            else return CalculateDiscount(total) * total;
        }

        static decimal CalculateTax(decimal amount)
        {
            return 0.18M * amount;
        }

        static decimal CalculateFInalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            int k = 0;
            foreach (var num in sales)
            {
                k++;
                if (num <= 5000) Console.WriteLine($"Day {k} : {categories[0]}");
                else if (num > 5000 && num < 15000) Console.WriteLine($"Day {k} : {categories[1]}");
                else if (num >= 15000) Console.WriteLine($"Day {k} : {categories[2]}");
            }
        }
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            ReadWeeklySales(sales);

            decimal total = CalculateTotal(sales, 0);
            decimal avg = CalculateAverage(total, sales.Length);
            Console.WriteLine();
            Console.WriteLine($"Total Sales {":",9} {total}");
            Console.WriteLine($"Average Daily Sale {":",2} {avg:F4}");

            int maxDay, minDay;
            decimal maxSale = FindHighestSale(sales, out maxDay);
            decimal minSale = FindLowestSale(sales, out minDay);
            Console.WriteLine($"Highest Sale {":",8} {maxSale} (Day{maxDay + 1})");
            Console.WriteLine($"Lowest Sale {":",9} {minSale} (Day{minDay + 1})");



            decimal discount = CalculateDiscount(total, false);
            Console.WriteLine($"Discount Applied {":",4} {discount:F4}");


            decimal tax = CalculateTax(total - discount);
            Console.WriteLine($"Tax Amount {":",10} {tax:F4}");


            decimal finalAmount = CalculateFInalAmount(total, discount, tax);
            Console.WriteLine($"Final Payable {":",7} {finalAmount:F4}");

            string[] categories = { "LOW", "MEDIUM", "HIGH" };
            Console.WriteLine();
            GenerateSalesCategory(sales, categories);
        }
    }
}
