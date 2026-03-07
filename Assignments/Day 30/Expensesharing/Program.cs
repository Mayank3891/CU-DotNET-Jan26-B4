using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public decimal Paid { get; set; }
    public decimal Balance { get; set; }

    public Person(string name, decimal paid)
    {
        Name = name;
        Paid = paid;
    }
}

class Transaction
{
    public string Payer { get; set; }
    public string Receiver { get; set; }
    public decimal Amount { get; set; }

    public Transaction(string payer, string receiver, decimal amount)
    {
        Payer = payer;
        Receiver = receiver;
        Amount = amount;
    }
}

class Program
{
    static List<Transaction> SettleExpenses(List<Person> people)
    {
        decimal total = people.Sum(p => p.Paid);
        decimal fairShare = total / people.Count;

        foreach (var p in people)
            p.Balance = Math.Round(p.Paid - fairShare, 2);

        var creditors = people.Where(p => p.Balance > 0)
                              .OrderByDescending(p => p.Balance)
                              .ToList();

        var debtors = people.Where(p => p.Balance < 0)
                            .OrderBy(p => p.Balance)
                            .ToList();

        List<Transaction> transactions = new List<Transaction>();

        int i = 0, j = 0;

        while (i < debtors.Count && j < creditors.Count)
        {
            var debtor = debtors[i];
            var creditor = creditors[j];

            decimal amount = Math.Min(-debtor.Balance, creditor.Balance);
            amount = Math.Round(amount, 2);

            transactions.Add(new Transaction(debtor.Name, creditor.Name, amount));

            debtor.Balance += amount;
            creditor.Balance -= amount;

            if (debtor.Balance == 0) i++;
            if (creditor.Balance == 0) j++;
        }

        return transactions;
    }

    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person("Aman",900),
            new Person("Soman",0),
            new Person("Kartik",1290)
        };

        var transactions = SettleExpenses(people);

        foreach (var t in transactions)
            Console.WriteLine($"{t.Payer} -> {t.Receiver} : {t.Amount:F2}");
    }
}
