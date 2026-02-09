
using System.Runtime.InteropServices.Marshalling;
using System.IO;

namespace Loanportfolio
{
    class RestrictedDestinationexception : Exception
    {
        public RestrictedDestinationexception(string destination) { 

            Console.WriteLine($"your destination is restricted{destination}");
        }
    }
    class Insecurepackagingexception : Exception
    {
        public Insecurepackagingexception()
        {
            Console.WriteLine("your package is insecure to ship");
        }
    }
    abstract class Shipment
    {
        public string TrackingId {  get; set; }
        public string Destination {  get; set; }
        public double weight {  get; set; }
        public bool isFragile {  get; set; }
        public bool isReinforced {  get; set; }


        public Shipment(string tracking

        public virtual void Processing() { }
    }
  
    class Expressshipment : Shipment
    {
        public Expressshipment(string trackingId, double weight,string destination,bool fragile,bool rein) : base(TrackingId, weight, destination, isFragile, isReinforced)
        {

        }
        public override void Processing()
        {
            HashSet<string> ht = new HashSet<string>()
            {
               "north pole","unknown island"
            };
            if (weight <=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (ht.Contains(Destination))
            {
                throw new RestrictedDestinationexception(Destination);
            }
            if(isFragile && !isReinforced)
            {
                throw new Insecurepackagingexception();
            }

        }
    }
    class HeavyFreight:Shipment
    {
        public override void Processing()
        {
            bool isPermit = true;
            HashSet<string> ht = new HashSet<string>()
            {
               "north pole","unknown island"
            };
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (ht.Contains(Destination))
            {
                throw new RestrictedDestinationexception(Destination);
            }
            if (isFragile && !isReinforced)
            {
                throw new Insecurepackagingexception();
            }
            if(weight>=1000&& !isPermit)
            {
                throw new Exception("Permit required");
            }

        }
    }
    interface Iloggable
    {
        public void savelog(string message);
    }
    class Logmanager : Iloggable
    {
        string path = "../../../shipment_audit.log";
        
        public void savelog(string message)
        {
            
                using StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(message);
            

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Iloggable loggable = new Logmanager();
            loggable.savelog("==================Application started====================");

            List<Shipment> shipments = new List<Shipment>()
            {
                new Expressshipment(TrackingId="A1",Destination="north pole",weight=654,isFragile=true,isReinforced=true),


            };
        }
    }
}
