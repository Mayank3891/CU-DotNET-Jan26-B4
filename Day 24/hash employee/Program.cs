using System.Collections;

namespace hash_employee
{
    internal class Program
    {
        public  static void details( Hashtable e,int id, string name)
        {
            if (e.ContainsKey(id))
            {
                Console.WriteLine("ID already exists");
            }
            else { 
                e.Add(id, name);
                Console.WriteLine("Employee details added");
            }
        }
        static void Main(string[] args)
        {
            Hashtable emp = new Hashtable();
            details(emp, 101, "Alice");

            details(emp, 102, "Bob");
            details(emp, 101, "Charlie");
            details(emp, 104, "Diana");



            Object emp1 = emp[102];
            Console.WriteLine("");
            string p = (string)emp1;
            Console.WriteLine($"Name of employee is {p}");
            Console.WriteLine("");
            foreach(DictionaryEntry entry in emp)
            {
                Console.WriteLine($"ID:{entry.Key} Name: {entry.Value}");
            }

            emp.Remove(103);
            Console.WriteLine("");
            Console.WriteLine($"Total employee are:{emp.Count}");
        }
    }
}
