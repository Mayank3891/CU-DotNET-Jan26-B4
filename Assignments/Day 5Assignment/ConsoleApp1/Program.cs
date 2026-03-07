using GreetingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter your name :");
            string a =Console.ReadLine();
            string b= GreetingHelper.GetGreeting(a);
            Console.WriteLine(b);
           
        }
    }
}
