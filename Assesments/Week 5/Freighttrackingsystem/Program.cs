namespace Freighttrackingsystem
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string location) : base($"Destination {location} is restricted") {

            
        }
    }
    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException() : base($"Packaging is insecure to ship ")
        {

            
        }
    }
     public abstract class Shipment
    {
        public string TrackingId {  get; set; }
        public double weight {  get; set; }
        public string Destination { get; set; }
        public bool Isfragile {  get; set; }
        public bool Isreinforced { get; set; }

        public static HashSet<string> restrictedzones= new HashSet<string> { "North pole","Unknown Island"}
            ;
        public  abstract void  Processing();
    }

    class ExpresShipment : Shipment
    {
             public  override void Processing()
        {
            if (weight<=0)
            {
                throw new ArgumentOutOfRangeException("weight must be greater than zero");
            }
            if (restrictedzones.Contains(Destination))
            {
                throw new RestrictedDestinationException(Destination);
            }
            if( Isfragile && !Isreinforced)
            {
                throw new InsecurePackagingException();
            }
            Console.WriteLine($"Shipment with Package id  :  {TrackingId}  processed");
            Console.WriteLine();
        }

    }
    class HeavyFreight : Shipment
    {
        public bool Ispermit {  get; set; }
        public override void Processing()
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException("weight","Weight must be greater than zero");
            }
            if (restrictedzones.Contains(Destination))
            {
                throw new RestrictedDestinationException(Destination);
            }
            if (weight>=1000&&!Ispermit)
            {
                throw new Exception("Weight Lift Permit Required");
            }


            Console.WriteLine($"Shipment with Package id  :   {TrackingId}   processed");
            Console.WriteLine("");
        }

    }
    public interface ILogggable
    {
        public void saveLog(string message);
    }
    public class Logmanager : ILogggable
    {
        string path = "../../../shipment_audit.log";
        public void saveLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine($"Date of shipment is : {DateTime.Now}");
               
                writer.WriteLine(message);
                writer.WriteLine();
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogggable logger= new Logmanager();
            logger.saveLog(" ===========Application started===========");
            List<Shipment> shipments = new List<Shipment>()
            {
                new ExpresShipment{TrackingId="A1" ,weight=768, Destination="east pole",Isfragile=true,Isreinforced=true},
                new ExpresShipment{TrackingId="A2" ,weight=899, Destination="Northeast",Isfragile=true,Isreinforced=false},
                new ExpresShipment{TrackingId="A3" ,weight=1000, Destination="south",Isfragile=false,Isreinforced=true},
                new ExpresShipment{TrackingId="A4" ,weight=1000, Destination="North pole",Isfragile=false,Isreinforced=true},
                new ExpresShipment{TrackingId="A5" ,weight=0, Destination="North pole",Isfragile=false,Isreinforced=true},
                new HeavyFreight{TrackingId="H1" ,weight=999, Destination="east",Ispermit=true},
                new HeavyFreight{TrackingId="H2" ,weight=1001, Destination="west",Ispermit=false}

            };

            foreach (var shipment in shipments)
            {
                try
                {
                    shipment.Processing();
                }
               
                catch (RestrictedDestinationException ex)
                {
                    logger.saveLog($"{shipment.TrackingId}  : {ex.Message}");
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    logger.saveLog($"{shipment.TrackingId}  : {ex.Message}");
                }
                catch (InsecurePackagingException ex)
                {
                    logger.saveLog($"{shipment.TrackingId}  : Weight must be greater than zero");
                }
                catch (Exception ex)
                {
                    logger.saveLog($"{shipment.TrackingId}  : {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"  Processing attempt for  : {shipment.TrackingId} finished ");
                    Console.WriteLine("");
                }
            }
        }
    }
}
