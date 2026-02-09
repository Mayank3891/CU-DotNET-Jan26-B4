using System;
namespace Day22
{
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public OLADriver(int id, string name, string vehicleNo)
        {
            Id = id;
            Name = name;
            VehicleNo = vehicleNo;
            Rides = new List<Ride>();
        }

        public void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }
    }

    class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }

        public Ride(int rideID, string from, string to, decimal fare)
        {
            RideID = rideID;
            From = from;
            To = to;
            Fare = fare;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();
            for (int i = 1; i <= 10; i++)
            {
                OLADriver driver = new OLADriver(i, $"Driver{i}", $"VEH{i:000}");
                for (int j = 1; j <= 3; j++)
                {
                    Ride ride = new Ride(j, $"Location{j}A", $"Location{j}B", 100 + (i * 10) + (j * 5));
                    driver.AddRide(ride);
                }
                drivers.Add(driver);
            }
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Driver ID: {driver.Id}, Name: {driver.Name}, Vehicle No: {driver.VehicleNo}");
                decimal totalFare = 0;
                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine($"\tRide ID: {ride.RideID}, From: {ride.From}, To: {ride.To}, Fare: {ride.Fare}");
                    totalFare += ride.Fare;
                }
                Console.WriteLine($"\tTotal Fare for Driver {driver.Name}: {totalFare}\n");
            }
        }
    }
}