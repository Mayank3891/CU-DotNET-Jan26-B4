namespace carproject.backend.Model
{

    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public string FuelType { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;
    }
}
