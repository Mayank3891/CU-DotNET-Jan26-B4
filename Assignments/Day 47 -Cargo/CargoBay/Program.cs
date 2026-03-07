namespace CargoBay
{
    public class Item
    {
        public string name { get; set; }
        public double weight { get; set; }
        public string category { get; set; }

        public Item(string name,double weight,string category)
        {
            this.name = name;
            this.weight = weight;
            this.category = category;

        }

    }
    public class Container
    {
        public string ContainerId { get; set; }
        public List<Item> Items { get; set; }
        public Container(string ContainerId,List<Item> Items){
            this.ContainerId = ContainerId;
            this.Items = Items;
            }
    }
    class ContainerProcessing
    {
        public List<List<Container>> CargoBay { get; set; }

        public ContainerProcessing(List<List<Container>> CargoBay)
        {
            this.CargoBay = CargoBay;
        }
        public List<string> FindHeavyContainers(double weightThreshold)
        {
            List<string> result = new List<string>();
            if (CargoBay == null)
            {
                return result;
            }
            
            foreach(var c in CargoBay)
            {
                foreach(var Container in c)
                {
                    if (Container.Items == null) {
                        continue;
                    }
                    double totalweight = Container.Items.Sum(i => i.weight);
                    if (totalweight > weightThreshold)
                    {
                        result.Add(Container.ContainerId);
                    }
                }

            }





            return result;
        }
        public Dictionary<string,int> GetitemCountByCategory()
        {    if(CargoBay==null)
            return new Dictionary<string, int>();
            return CargoBay.SelectMany(r => r).SelectMany(c => c.Items).GroupBy(g => g.category).ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Item> FlattenandShortShipment()
        {

            var item = CargoBay.SelectMany(r => r).SelectMany(c=>c.Items).OrderBy(g=>g.category).ThenByDescending(i=>i.weight).Distinct().ToList();


            return item;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
    
            
            var cargoBay = new List<List<Container>>
{
    // ROW 0: High-Value Tech Row
    new List<Container>
    {
        new Container("C001", new List<Item>
        {
            new Item("Laptop", 2.5, "Tech"),
            new Item("Monitor", 5.0, "Tech"),
            new Item("Smartphone", 0.5, "Tech")
        }),
        new Container("C104", new List<Item>
        {
            new Item("Server Rack", 45.0, "Tech"), // Heavy Item
            new Item("Cables", 1.2, "Tech")
        })
    },

    // ROW 1: Mixed Consumer Goods
    new List<Container>
    {
        new Container("C002", new List<Item>
        {
            new Item("Apple", 0.2, "Food"),
            new Item("Banana", 0.2, "Food"),
            new Item("Milk", 1.0, "Food")
        }),
        new Container("C003", new List<Item>
        {
            new Item("Table", 15.0, "Furniture"),
            new Item("Chair", 7.5, "Furniture")
        })
    },

    // ROW 2: Fragile & Perishables (Includes an Empty Container)
    new List<Container>
    {
        new Container("C205", new List<Item>
        {
            new Item("Vase", 3.0, "Decor"),
            new Item("Mirror", 12.0, "Decor")
        }),
        new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
    },

    // ROW 3: EDGE CASE - Empty Row
    new List<Container>() // A row that exists but has no containers
};

            List<string> st = new List<string>();
            ContainerProcessing process = new ContainerProcessing(cargoBay);
            Console.WriteLine("--ITEMS ABOVE THREESOLD WEIGHT --");
            Console.WriteLine();
           st= process.FindHeavyContainers(2);
            foreach(var id in st)
            {
                Console.WriteLine(id);
            }
            Console.WriteLine("--ITEMS CATEGORYWISE --");
            Console.WriteLine();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict = process.GetitemCountByCategory();
            foreach(var r in dict)
            {
                Console.WriteLine($"{r.Key}-{r.Value}");
            }
            List<Item> items = new List<Item>();
            Console.WriteLine("--ITEMS LIST --");
            Console.WriteLine();
            items = process.FlattenandShortShipment();
            foreach (var r in items)
            {
                Console.WriteLine($"{r.name} - {r.category} - {r.weight}");
                Console.WriteLine();
            }


        }
    }
}
