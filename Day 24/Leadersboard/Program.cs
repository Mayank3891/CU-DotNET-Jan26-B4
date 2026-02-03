namespace Leadersboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double,string> lead = new SortedDictionary<double,string>();

            lead.Add(55.42, "SwiftRacer");
            lead.Add(52.10, "SpeedDemon");
            lead.Add(58.91, "SteadyEddie");
            lead.Add(51.05, "TurboTom");

            foreach (var k in lead) {
                Console.WriteLine($"Time is   :{k.Key} and name is  :{k.Value}");
            }
            var fastest = lead.First();
            Console.WriteLine("");
            Console.WriteLine($"Fastest racer is :{fastest}");
            double r = 0;
            string st = "SteadyEddie";
            foreach (var h in lead)
            {
                if (st == h.Value) 
                {
                    r = h.Key;
                }
            }
            lead.Remove(r);
            lead.Add(54.00, "SteadyEddie");
            Console.WriteLine("");
            foreach (var k in lead)
            {
                Console.WriteLine($"Time is   :{k.Key} and name is  :{k.Value}");
            }

        }
    }
}
