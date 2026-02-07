namespace Daillogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your daily reflection");

            string path = "../../../journal.txt";
            if (!File.Exists(path))
            {
                File.Create(path );
            }

            using StreamWriter sw = new StreamWriter(path,true);
            string? daily=Console.ReadLine();
            sw.WriteLine(daily);
            
        }
    }
}
