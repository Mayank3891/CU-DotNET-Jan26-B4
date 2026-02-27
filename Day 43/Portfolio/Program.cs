using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FinancialPortfolio
{
    abstract class FinancialInstrument
    {
        private decimal quantity;
        private decimal purchasePrice;
        private decimal marketPrice;

        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get => quantity;
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Invalid Quantity");
                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => purchasePrice;
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Invalid Purchase Price");
                purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get => marketPrice;
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Invalid Market Price");
                marketPrice = value;
            }
        }

        protected FinancialInstrument(string id, string name, string currency,
            DateTime date, decimal qty, decimal purchase, decimal market)
        {
            if (currency.Length != 3)
                throw new InvalidFinancialDataException("Invalid Currency");

            InstrumentId = id;
            Name = name;
            Currency = currency;
            PurchaseDate = date;
            Quantity = qty;
            PurchasePrice = purchase;
            MarketPrice = market;
        }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} {Name} {CalculateCurrentValue():C}";
        }
    }

    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public Equity(string id, string name, string currency,
            DateTime date, decimal qty, decimal purchase, decimal market)
            : base(id, name, currency, date, qty, purchase, market) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId},{Name},{CalculateCurrentValue():C}";
        }
    }

    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public Bond(string id, string name, string currency,
            DateTime date, decimal qty, decimal purchase, decimal market)
            : base(id, name, currency, date, qty, purchase, market) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Medium";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId},{Name},{CalculateCurrentValue():C}";
        }
    }

    class FixedDeposit : FinancialInstrument
    {
        public FixedDeposit(string id, string name, string currency,
            DateTime date, decimal qty, decimal purchase, decimal market)
            : base(id, name, currency, date, qty, purchase, market) { }

        public override decimal CalculateCurrentValue()
        {
            return MarketPrice;
        }
    }

    class MutualFund : FinancialInstrument, IRiskAssessable, IReportable
    {
        public MutualFund(string id, string name, string currency,
            DateTime date, decimal qty, decimal purchase, decimal market)
            : base(id, name, currency, date, qty, purchase, market) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Medium";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId},{Name},{CalculateCurrentValue():C}";
        }
    }

    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public decimal Units { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string id, string instrumentId, string type, decimal units, DateTime date)
        {
            TransactionId = id;
            InstrumentId = instrumentId;
            Type = type;
            Units = units;
            Date = date;
        }
    }

    class Portfolio
    {
        private List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        private Dictionary<string, FinancialInstrument> lookup =
            new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
                throw new InvalidFinancialDataException("Duplicate Instrument");

            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }

        public FinancialInstrument GetInstrumentById(string id)
        {
            return lookup.ContainsKey(id) ? lookup[id] : null;
        }

        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public void ProcessTransactions(Transaction[] transactions)
        {
            List<Transaction> list = transactions.ToList();

            foreach (var t in list)
            {
                var instrument = GetInstrumentById(t.InstrumentId);
                if (instrument == null) continue;

                if (t.Type == "Buy")
                    instrument.Quantity += t.Units;
                else if (t.Type == "Sell")
                {
                    if (instrument.Quantity < t.Units)
                        throw new InvalidFinancialDataException("Insufficient Units");
                    instrument.Quantity -= t.Units;
                }
            }
        }

        public List<FinancialInstrument> GetAll()
        {
            return instruments;
        }
    }

    class ReportGenerator
    {
        public void GenerateConsoleReport(Portfolio portfolio)
        {
            var groups = portfolio.GetAll().GroupBy(i => i.GetType().Name);

            Console.WriteLine("===== PORTFOLIO SUMMARY =====");

            foreach (var g in groups)
            {
                decimal investment = g.Sum(x => x.PurchasePrice * x.Quantity);
                decimal current = g.Sum(x => x.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: {g.Key}");
                Console.WriteLine($"Total Investment: {investment:C}");
                Console.WriteLine($"Current Value: {current:C}");
                Console.WriteLine($"Profit/Loss: {(current - investment):C}");
                Console.WriteLine();
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
        }

        public void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("PORTFOLIO REPORT");
                sw.WriteLine(DateTime.Now);

                foreach (var i in portfolio.GetAll())
                    sw.WriteLine(i.GetInstrumentSummary());

                sw.WriteLine($"Total Value: {portfolio.GetTotalPortfolioValue():C}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio();

            Equity eq = new Equity("EQ001", "INFY", "INR", DateTime.Now, 100, 1500, 1650);
            Bond bond = new Bond("BD001", "GOVT", "INR", DateTime.Now, 50, 1000, 1050);
            FixedDeposit fd = new FixedDeposit("FD001", "SBI FD", "INR", DateTime.Now, 1, 50000, 52000);
            MutualFund mf = new MutualFund("MF001", "HDFC MF", "INR", DateTime.Now, 200, 100, 120);

            portfolio.AddInstrument(eq);
            portfolio.AddInstrument(bond);
            portfolio.AddInstrument(fd);
            portfolio.AddInstrument(mf);

            Transaction[] transactions =
            {
                new Transaction("T1","EQ001","Buy",10,DateTime.Now),
                new Transaction("T2","MF001","Sell",20,DateTime.Now)
            };

            portfolio.ProcessTransactions(transactions);

            ReportGenerator generator = new ReportGenerator();
            generator.GenerateConsoleReport(portfolio);
            generator.GenerateFileReport(portfolio);
        }
    }
}
