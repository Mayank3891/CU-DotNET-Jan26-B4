using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingLibrary
{
    public class GreetingHelper
    {
        public static string GetGreeting(string name)
        {
            if (String.IsNullOrEmpty(name)) return "Hello Guest";
            else return "Hello " + name;
        }
    }
}
