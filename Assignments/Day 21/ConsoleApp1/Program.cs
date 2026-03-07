using System;
using System.Collections.Generic;

class Policy
{
    public string HolderName { get; set; }
    public decimal Premium { get; set; }
    public int RiskScore { get; set; }
    public DateTime RenewalDate { get; set; }
}

class PolicyTracker
{
    Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

    public void AddPolicy(string id, Policy policy)
    {
        policies[id] = policy;
    }

    public void BulkAdjustment()
    {
        foreach (var kvp in policies)
        {
            if (kvp.Value.RiskScore > 75)
            {
                kvp.Value.Premium = kvp.Value.Premium * 1.05m;
            }
        }
    }

    public void CleanUp()
    {
        foreach (var key in new List<string>(policies.Keys))
        {
            if (policies[key].RenewalDate < DateTime.Now.AddYears(-3))
            {
                policies.Remove(key);
            }
        }
    }

    public string SecurityCheck(string id)
    {
        if (policies.ContainsKey(id))
        {
            var p = policies[id];
            return $"Holder: {p.HolderName}, Premium: {p.Premium}, RiskScore: {p.RiskScore}, RenewalDate: {p.RenewalDate}";
        }
        else
        {
            return "Not Found";
        }
    }
}

class Program
{
    static void Main()
    {
        PolicyTracker tracker = new PolicyTracker();
        tracker.AddPolicy("P001", new Policy { HolderName = "John", Premium = 1000m, RiskScore = 80, RenewalDate = DateTime.Now.AddYears(-1) });
        tracker.AddPolicy("P002", new Policy { HolderName = "Alice", Premium = 1200m, RiskScore = 60, RenewalDate = DateTime.Now.AddYears(-4) });
        tracker.BulkAdjustment();
        tracker.CleanUp();
        Console.WriteLine(tracker.SecurityCheck("P001"));
        Console.WriteLine(tracker.SecurityCheck("P002"));
        Console.WriteLine(tracker.SecurityCheck("P003"));
    }
}