namespace SimpleUserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split("|", StringSplitOptions.TrimEntries);

            string userName = inputArr[0];
            string loginMsg = inputArr[1].ToLower();

            string status;
            if (loginMsg.Contains("successful"))
            {
                if (loginMsg.Equals("login successful")) status = "LOGIN SUCCESS";
                else status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }
            else status = "LOGIN FAILED";

            Console.WriteLine($"User {":",4} {userName}");
            Console.WriteLine($"Message {":",1} {loginMsg}");
            Console.WriteLine($"Status {":",2} {status}");
        }
    }
}