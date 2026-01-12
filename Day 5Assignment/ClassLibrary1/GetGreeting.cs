namespace GreetingLibrary
{
    public class GreetingHelper
    {
        public static string GetGreeting(string name)
        {
            if(name == null)
            {
                return "hello guest";

            }
            else
            {
                return"hello" +name;
            }
        }
    }
}
