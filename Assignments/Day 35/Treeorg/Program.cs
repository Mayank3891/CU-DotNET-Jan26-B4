
public class EmployeeNode
{
    public string Name { get; set; }
    public string Position { get; set; }
    public List<EmployeeNode> Reports { get; set; } = new List<EmployeeNode>();

    public EmployeeNode(string name, string position)
    {
        Name = name;
        Position = position;
    }
    public void AddReport(EmployeeNode employee)
    {
        Reports.Add(employee);
    }
}

public class OrganizationTree
{
    public EmployeeNode Root { get; private set; }

    public OrganizationTree(EmployeeNode rootEmployee)
    {
        Root = rootEmployee;
    }

    public void DisplayFullHierarchy()
    {
        PrintRecursive(Root, 0);
    }

    private void PrintRecursive(EmployeeNode current, int depth)
    {
        if (current == null)
        {
            return;
        }
        for (int i = 0; i < depth; i++)
        {
            Console.Write("   ");
        }

        Console.WriteLine($"->{current.Name}-{current.Position}");
        foreach (var report in current.Reports)
        {
            PrintRecursive(report, depth+1);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        var ceo = new EmployeeNode("Aman", "CEO");
        var cto = new EmployeeNode("Suresh", "CTO");
        var manager = new EmployeeNode("Sonia", "Dev Manager");
        var dev1 = new EmployeeNode("Sara", "Senior Dev");
        var dev2 = new EmployeeNode("Divakar", "Junior Dev");
        var cfo = new EmployeeNode("Rajesh", "CFO");
        var acccOfficer = new EmployeeNode("Rajat", "Account Officer");

        
        var company = new OrganizationTree(ceo);

        ceo.AddReport(cto);

        cto.AddReport(manager);
        manager.AddReport(dev1);
        manager.AddReport(dev2);

        ceo.AddReport(cfo);
        cfo.AddReport(acccOfficer);

        company.DisplayFullHierarchy();
    }
}

