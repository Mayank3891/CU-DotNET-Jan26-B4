namespace OrderClass
{
    internal class Order
    {
        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
        }

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrEmpty(value)) _customerName = value;
                else Console.WriteLine("Wrong Input");
            }
        }

        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        DateTime date;
        string status;
        public Order()
        {
            date = DateTime.Now;
            ;
            status = "NEW";
        }

        public Order(int id, string name)
        {
            date = DateTime.Now;
            status = "NEW";
            _orderId = id;
            _customerName = name;
        }

        public void AddItem(decimal price)
        {
            _totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            _totalAmount = (int)(_totalAmount - (_totalAmount * (percentage / 100)));
        }

        public void GetOrderSummary()
        {
            Console.WriteLine($"Order ID : {OrderId}\nCustomer : {CustomerName}\nTotal Amount : {TotalAmount}\nStatus : {status}\n Date : {date}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order(101, "Aaroh");
            o1.AddItem(500);
            o1.AddItem(300);
            o1.ApplyDiscount(10);
            o1.GetOrderSummary();

            Console.WriteLine();

            Order o2 = new Order(102, "Mayank");
            o2.AddItem(500);
            o2.AddItem(1000);
            o2.ApplyDiscount(10);
            o2.GetOrderSummary();

        }
    }
}
