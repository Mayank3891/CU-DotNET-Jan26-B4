namespace Kitchenappliance
{
    interface Itimer
    {
        void Settimer(int minutes);
    }
    interface Iwifi
    {
        void connectwifi();
    }
    abstract class KitchenDevice
    {
        public string Modelname { get; set; }
        public int Powerconsumption { get; set; }

        public KitchenDevice(string modelname, int powerconsumption)
        {
            Modelname = modelname;
            Powerconsumption = powerconsumption;
        }
        public abstract void cook();
        public virtual void Preheat()
        {
            Console.WriteLine("Appliance require   Preheat");
        }
    }

    class Microwave : KitchenDevice,Itimer
    {
        public Microwave(string modelname, int powerconsumption) : base(modelname, powerconsumption)
        {
        }
        public override void cook()
        {
            Console.WriteLine($"Microwave: {Modelname} IS cooking food");
        }
        public void Settimer(int minutes)
        {
            Console.WriteLine($"Microwave is set for {minutes}");
        }
    }

    class Oven : KitchenDevice, Itimer, Iwifi
    {
        public Oven(string modelname, int powerconsumption) : base(modelname, powerconsumption)
        {
        }
      
        public override void cook()
        {
            Console.WriteLine($"Microwave: {Modelname} IS cooking food");
        }
        public void Settimer(int minutes)
        {
            Console.WriteLine($"Microwave is set for {minutes}");
        }
        public void connectwifi()
        {
            Console.WriteLine("Oven is being connected to wifi");
        }
    }
    class Airfryer : KitchenDevice
    {
        public Airfryer(string modelname, int powerconsumption) : base(modelname, powerconsumption)
        {
        }
        public override void cook()
        {
            Console.WriteLine("airfryer is cookin food");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenDevice> kd = new List<KitchenDevice>()
            {
                new Microwave("abc",9876),
                new Oven("cgd",9876),
                new Airfryer("uv",9876)
            };

            foreach(var appliance  in kd)
            {
                appliance.cook();
                appliance.Preheat();
                if(appliance is Itimer timerapp)
                {
                    timerapp.Settimer(78);
                }
                if(appliance is Iwifi wiapp)
                {
                    wiapp.connectwifi();
                }
            }

            

        }
    }
}
