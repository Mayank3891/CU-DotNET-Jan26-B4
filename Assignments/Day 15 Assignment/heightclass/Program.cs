namespace HeightClass
{
    internal class Height
    {
        public int Feet { get; set; }

        public decimal Inches { get; set; }

        public Height()
        {
            Feet = 0;
            Inches = 0.0M;
        }

        public Height(int feet, decimal inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public Height(decimal inches)
        {
            if (inches >= 12) Feet = (int)(inches / 12.0M);
            Inches = (inches % 12);

        }

        public static Height operator +(Height h1, Height h2)
        {
            decimal temp_inches = h1.Inches + h2.Inches;
            int temp_feet = h1.Feet + h2.Feet;
            if (temp_inches >= 12)
            {
                temp_feet += (int)(temp_inches / 12);
                temp_inches = temp_inches % 12;
            }

            Height addedHeight = new Height(temp_feet, temp_inches);
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
            Height h1 = new Height()
            {
                Feet = 5,
                Inches = 6.1Mss
            };


            Height h2 = new Height(6, 6.1M);

            Height h3 = new Height(75);

            Console.WriteLine($"Height - {h1}");
            Console.WriteLine($"Height - {h2}");
            Console.WriteLine($"Total Height - {h1 + h2}");
        }
    }
}