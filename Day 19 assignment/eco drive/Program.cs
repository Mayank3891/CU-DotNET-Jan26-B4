using System;
abstract class Vehicle
{
    public string ModelName { get; set; }

    public Vehicle(string modelName)
    {
        ModelName = modelName;
    }
    public abstract void Move();
    public virtual string GetFuelStatus()
    {
        return "Fuel level is stable.";
    }
}
class ElectricCar : Vehicle
{
    public ElectricCar(string modelName) : base(modelName)
    {
    }

    public override void Move()
    {
        Console.WriteLine($"{ModelName} is running silently on battery power.");
    }

    public override string GetFuelStatus()
    {
        return $"{ModelName} battery is at 80%.";
    }
}
class HeavyTruck : Vehicle
{
    public HeavyTruck(string modelName) : base(modelName)
    {
    }

    public override void Move()
    {
        Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
    }

}
class CargoPlane : Vehicle
{
    public CargoPlane(string modelName) : base(modelName)
    {
    }

    public override void Move()
    {
        Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
    }

    public override string GetFuelStatus()
    {
        string baseFuelStatus = base.GetFuelStatus();
        return baseFuelStatus + " Checking jet fuel reserves...";
    }
}

class Program
{
    static void Main()
    {
        Vehicle[] fleet = new Vehicle[]
        {
            new ElectricCar("Tesla Model"),
            new HeavyTruck("Volvo"),
            new CargoPlane("Boeing")
        };
        foreach (Vehicle vehicle in fleet)
        {
            Console.WriteLine("\n--- Vehicle Information ---");
            vehicle.Move();
            Console.WriteLine(vehicle.GetFuelStatus());
        }
    }
}
