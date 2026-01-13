namespace SmartAccessControl
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string log = Console.ReadLine();
            Console.WriteLine("\n");
            string[] s = log.Split("|");

            bool validation = true;

            string GateCode = s[0];
            if (GateCode.Length != 2 || !char.IsDigit(GateCode[1]) || !char.IsLetter(GateCode[0])) validation = false;

            char UserInitial = char.Parse(s[1]);
            if (!char.IsUpper(UserInitial)) validation = false;

            byte AccessLevel = byte.Parse(s[2]);
            if (AccessLevel < 1 || AccessLevel > 7) validation = false;

            bool IsActive = bool.Parse(s[3]);

            byte Attempts = byte.Parse(s[4]);
            if (Attempts > 200) validation = false;

            string status;

            if (!validation) Console.WriteLine("INVALID ACCESS LOG");
            else
            {
                if (!IsActive) status = "ACCESS DENIED – INACTIVE USER";

                else if (Attempts > 100) status = "ACCESS DENIED – TOO MANY ATTEMPTS";

                else if (AccessLevel >= 5) status = "ACCESS GRANTED – HIGH SECURITY";

                else status = "ACCESS GRANTED – STANDARD";

                Console.WriteLine($"Gate {":",6} {GateCode}");
                Console.WriteLine($"User {":",6} {UserInitial}");
                Console.WriteLine($"Level {":",5} {AccessLevel}");
                Console.WriteLine($"Attempts {":",2} {Attempts}");
                Console.WriteLine($"Status {":",4} {status}");

            }
        }
    }
}
