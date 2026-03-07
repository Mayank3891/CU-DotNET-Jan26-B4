namespace PrintLine
{
    internal class Program
    {
        static void PrintLine(char sign = '*', int num = 40)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(sign);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            PrintLine();
            PrintLine('$');
            PrintLine(num: 60, sign: 'a');
        }
    }
}