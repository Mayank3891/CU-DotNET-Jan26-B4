
namespace StreamCollection
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }
    internal class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        public static void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        public static Dictionary<string, int> GetTopPostCounts(double likeThreshold)
        {
            Dictionary<string, int> top = new Dictionary<string, int>();
            foreach (CreatorStats record in EngagementBoard)
            {
                string name = record.CreatorName;
                var a = record.WeeklyLikes;
                int count = 0;
                foreach (var b in a)
                {
                    if (b > likeThreshold) count++;
                }

                if (count != 0) top.Add(name, count);
            }

            return top;
        }

        public static double CalculateAverage()
        {
            return EngagementBoard.Sum(a => a.WeeklyLikes.Sum()) / (EngagementBoard.Count * 4);
        }

        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write
                    ("Enter your selections : ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    string name;
                    double[] arr = new double[4];
                    Console.WriteLine("Enter creator name = ");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter 4 weeks likes = ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    RegisterCreator(new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = arr
                    });

                }
                if (input == "2")
                {
                    Console.WriteLine("Enter Like Threshold = ");
                    double thresh = double.Parse(Console.ReadLine());


                    var best = GetTopPostCounts(thresh);

                    string top = "";

                    if (best.Count == 0) top = "No top - performing posts this week";
                    else
                    {
                        foreach (var dict in best)
                        {
                            top += dict.Key + " " + dict.Value + "\n";
                        }
                    }

                    Console.WriteLine(top);
                }

                if (input == "3")
                {
                    Console.WriteLine($"Overall Average = {CalculateAverage()}");
                }

                if (input == "4")
                {
                    Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}