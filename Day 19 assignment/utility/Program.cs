using System.Reflection.Metadata.Ecma335;

namespace UtilityBillingSystem
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }

        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal total = billAmount + tax;

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Consumer ID     : {ConsumerId}");
            Console.WriteLine($"Consumer Name   : {ConsumerName}");
            Console.WriteLine($"Units Consumed  : {UnitsConsumed}");
            Console.WriteLine($"Bill Amount     : ₹{billAmount}");
            Console.WriteLine($"Tax             : ₹{tax}");
            Console.WriteLine($"Total Payable   : ₹{total}");
            Console.WriteLine("------------------------------------------------\n");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;

            if (UnitsConsumed > 300)
            {
                billAmount = billAmount + (billAmount * 0.10m);
            }
            return billAmount;
        }
    }

    class GasBill : UtilityBill
    {
        int monthlyFixedCharge = 150;
        public override decimal CalculateBillAmount()
        {
            decimal billAmount = (UnitsConsumed * RatePerUnit) + monthlyFixedCharge;
            return billAmount;
        }
    }

    class WaterBill : UtilityBill
    {
        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.2m;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>
            {
                new ElectricityBill
                {
                    ConsumerId = 101,
                    ConsumerName = "Tushar Singh",
                    UnitsConsumed = 290,
                    RatePerUnit = 4.3m
                },
                new WaterBill
                {
                    ConsumerId = 102,
                    ConsumerName = "Sahil Ittan",
                    UnitsConsumed = 300,
                    RatePerUnit = 3.0m
                },
                new GasBill
                {
                    ConsumerId = 103,
                    ConsumerName = "Hrithik",
                    UnitsConsumed = 120,
                    RatePerUnit = 7.9m
                }
            };

            foreach (UtilityBill bill in bills)
            {
                bill.PrintBill();
            }
        }
    }
}
