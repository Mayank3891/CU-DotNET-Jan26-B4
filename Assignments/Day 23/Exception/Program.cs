namespace Exception
{
    internal class Program
    {
        public void checkex1(int x, int y)
        {
            try
            {
                int t = x / y;
            }
            catch(DivideByZeroException) {
                Console.WriteLine("Cannot divide by zero");
            }
        }
        

        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            try
            {
                int t = x / y;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }

            try
            {
                Console.WriteLine("enter number");
                int p = int.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("format exception  occured");
            }
            try
            {
                int[] k = {1, 2, 3, 4};
                int index;
                Console.WriteLine("Enter the index of number");
                index = int.Parse(Console.ReadLine());
                Console.WriteLine(k[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out of range exception");
            }




        }
    }
}
