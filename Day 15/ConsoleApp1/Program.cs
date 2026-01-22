namespace Heightclass
{
    internal class height
    {
        public int Feet { get; set; }
        public decimal Inches { get; set; }
        public height() {
            Feet = 0;
            Inches = 0.0M;
        }

        public height(int ft, decimal ics)
        {
            Feet = ft;
            Inches = ics;
        }
        public height(decimal inches)
        {
            if (inches >= 12) Feet = (int)(inches / 12.0M);
            inches = (inches % 12);

        }
        public height addheight(height h1, height h2)
        {
            decimal temp_inches = h1.Inches + h2.Inches;
            int temp_feet = h1.Feet + h2.Feet;
            if (temp_inches >= 12)
            {
                temp_feet += (int)(temp_inches / 12);
                temp_inches = temp_inches % 12;
            }

            height addedHeight = new height(temp_feet, temp_inches);
            return addedHeight;
        }
        public override string ToString()
        {
            return $"{Feet} feet {Inches} inches";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            height h1 = new height()
            {
                Feet = 5,
                    Inches = 6.1M
            };
            height h2 = new height(6, 6.1M);
            height h3 = new height(75);

            Console.WriteLine($"Height -- {h1}");
            Console.WriteLine($"Height -- {h2}");
            Console.WriteLine($"Total Height -- {h1.addheight(h1,h2)}");

        }
    }
}
