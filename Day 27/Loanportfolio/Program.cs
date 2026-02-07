using System;
using System.Collections.Generic;
using System.IO;

public class Loan
{
    public string ClientName { get; set; }
    public double Principal { get; set; }
    public double InterestRate { get; set; }
}

class Program
{
    static string filePath = "loans.csv";

    static void Main()
    {
        Console.WriteLine("===== Loan Portfolio Manager =====\n");

        AddLoan();
        Console.WriteLine("\n===== Loan Risk Report =====\n");
        List<Loan> loans = ReadLoans();

        DisplayLoans(loans);

        Console.WriteLine("\nProgram Finished.");
    }

    // ==============================
    // ADD LOAN (Append Mode)
    // ==============================
    static void AddLoan()
    {
        bool fileExists = File.Exists(filePath);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            // Write header only if file doesn't exist
            if (!fileExists)
            {
                writer.WriteLine("ClientName,Principal,InterestRate");
            }

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Principal Amount: ");
            string principalInput = Console.ReadLine();

            Console.Write("Enter Interest Rate (%): ");
            string rateInput = Console.ReadLine();

            // Safe parsing
            if (double.TryParse(principalInput, out double principal) &&
                double.TryParse(rateInput, out double rate))
            {
                writer.WriteLine($"{name},{principal},{rate}");
                Console.WriteLine("Loan added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid numeric input. Loan not added.");
            }
        }
    }

    // ==============================
    // READ LOANS FROM CSV
    // ==============================
    static List<Loan> ReadLoans()
    {
        List<Loan> loans = new List<Loan>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Loan file not found.");
            return loans;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // Skip header

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    continue;

                string name = parts[0];

                if (double.TryParse(parts[1], out double principal) &&
                    double.TryParse(parts[2], out double rate))
                {
                    Loan loan = new Loan
                    {
                        ClientName = name,
                        Principal = principal,
                        InterestRate = rate
                    };

                    loans.Add(loan);
                }
                else
                {
                    Console.WriteLine($"Invalid data found for client: {name}");
                }
            }
        }

        return loans;
    }

    // ==============================
    // DISPLAY LOANS WITH CALCULATIONS
    // ==============================
    static void DisplayLoans(List<Loan> loans)
    {
        foreach (var loan in loans)
        {
            double totalInterest = loan.Principal * loan.InterestRate / 100;
            string riskLevel = GetRiskLevel(loan.InterestRate);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Client Name    : {loan.ClientName}");
            Console.WriteLine($"Principal      : {loan.Principal:C}");
            Console.WriteLine($"Interest Rate  : {loan.InterestRate}%");
            Console.WriteLine($"Total Interest : {totalInterest:C}");
            Console.WriteLine($"Risk Category  : {riskLevel}");
        }
    }

    // ==============================
    // RISK LOGIC METHOD
    // ==============================
    static string GetRiskLevel(double rate)
    {
        if (rate > 10)
            return "High Risk";
        else if (rate >= 5 && rate <= 10)
            return "Medium Risk";
        else
            return "Low Risk";
    }
}
