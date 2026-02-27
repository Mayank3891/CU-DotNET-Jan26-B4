namespace Portfolio
{
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }
    interface IReportable
    {
        string GenerateReportLine();
    }
    public abstract class FinancialInstrunment{
        public int InstrunmentId { get; set; }
        public string Name { get; set; }
        public double Currency { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double MarketPrice { get; set; }

        public FinancialInstrunment(int InstrunmentId,string Name,double Currency,DateTime PurchaseDate,int Quantity,double PurchasePrice,double MarketPrice)
        {
            this.InstrunmentId = InstrunmentId;
            this.Name = Name;
            this.Currency = Currency;
            this.PurchaseDate = PurchaseDate;
            this.PurchasePrice = PurchasePrice;
            this.MarketPrice = MarketPrice;
        }
     public abstract decimal CalculateCurrentValue();
    public virtual string GetInstrunmentSummary()
    {
        return "";
    }
    }
    class Equity: FinancialInstrunment
    {
        public Equity(int InstrunmentId, string Name, double Currency, DateTime PurchaseDate, int Quantity, double PurchasePrice, double MarketPrice):base(InstrunmentId,Name,Currency,PurchaseDate,Quantity,PurchasePrice,MarketPrice)
        {
            
        }
        public override decimal CalculateCurrentValue()
        {
            return 9;
        }
        public override string GetInstrunmentSummary()
        {
            return "";
        }
    }
    class Bond : FinancialInstrunment
    {
        public Bond(int InstrunmentId, string Name, double Currency, DateTime PurchaseDate, int Quantity, double PurchasePrice, double MarketPrice) : base(InstrunmentId, Name, Currency, PurchaseDate, Quantity, PurchasePrice, MarketPrice)
        {

        }
        public override decimal CalculateCurrentValue()
        {
            return 9;
        }
        public override string GetInstrunmentSummary()
        {
            return "";
        }
    }
    class FixedDeposit : FinancialInstrunment
    {
        public FixedDeposit(int InstrunmentId, string Name, double Currency, DateTime PurchaseDate, int Quantity, double PurchasePrice, double MarketPrice) : base(InstrunmentId, Name, Currency, PurchaseDate, Quantity, PurchasePrice, MarketPrice)
        {

        }
        public override decimal CalculateCurrentValue()
        {
            return 9;
        }
        public override string GetInstrunmentSummary()
        {
            return "";
        }
    }
    class MutualFund : FinancialInstrunment
    {
        public MutualFund(int InstrunmentId, string Name, double Currency, DateTime PurchaseDate, int Quantity, double PurchasePrice, double MarketPrice) : base(InstrunmentId, Name, Currency, PurchaseDate, Quantity, PurchasePrice, MarketPrice)
        {

        }
        public override decimal CalculateCurrentValue()
        {
            return 9;
        }
        public override string GetInstrunmentSummary()
        {
            return "";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
