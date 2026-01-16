namespace Bank_transaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string h = Console.ReadLine();
            h = h.ToLower();
            string[] p = h.Split('#', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            string transid = p[0];
            string acct = p[1];
            string Narration = p[2];

            string[] validtrans = { "deposit", "withdraw", "transfer" };
            bool t = false;
            Console.WriteLine($"Transaction ID : {transid}\nAccount Holder :{acct}\nNarration      : {Narration}");
            if (string.IsNullOrEmpty(Narration))
            {
                Console.WriteLine("NON-FINANCIAL TRANSACTION");

            }
            else if (!string.IsNullOrEmpty(Narration))
            {
                {
                    for (int i = 0; i < validtrans.Length; i++)
                    {
                        if (Narration.Contains(validtrans[i]))
                        {
                            Console.WriteLine("Category       : STANDARD TRANSACTION");
                            t = true;
                        }

                    }
                    if (!t)
                    {
                        Console.WriteLine("CUSTOM TRANSACTION");
                    }

                }

            }
        }
    }
}
