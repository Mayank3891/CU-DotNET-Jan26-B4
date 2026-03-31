
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name = ");
            string name = Console.ReadLine();
            Console.WriteLine(GreetingHelper.GetGreeting(name));
        }
    }
}
