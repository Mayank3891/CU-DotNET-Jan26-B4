namespace SkyHigh
{


    public class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public int Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? flight)
        {
            return this.Price.CompareTo(flight.Price); ;
        }
        public override string ToString()
        {
            return $"{FlightNumber}  {Price}  {Duration}  {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight f1, Flight f2)
        {
            return f1.Duration.CompareTo(f2.Duration);
        }

    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight f1, Flight f2)
        {
            return f1.DepartureTime.CompareTo(f2.DepartureTime);
        }

    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
        {
            new Flight() {
                FlightNumber= "1",
                    Price=5500,
                    Duration=TimeSpan.FromHours(2),
                    DepartureTime = DateTime.Now,
            },
            new Flight()
            {
                FlightNumber= "2",
                    Price=8760,
                    Duration=TimeSpan.FromHours(2),
                    DepartureTime = DateTime.Now,
            },
            new Flight()
            {
                FlightNumber= "3",
                    Price=9870,
                    Duration=TimeSpan.FromHours(2),
                    DepartureTime = DateTime.Now,
            }
        };

            Console.WriteLine(" Sorted by Price ");
            flights.Sort();
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(flights[i]);
            }
            Console.WriteLine(" Sorted by Duration ");
            flights.Sort(new DurationComparer());
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(flights[i]);
            }
            Console.WriteLine(" Sorted by Departure time ");
            flights.Sort(new DepartureComparer());
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(flights[i]);
            }




        }
    }
}
