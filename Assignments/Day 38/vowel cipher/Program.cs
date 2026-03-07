using System;
using System.Collections.Generic;

class Program
{
    static string VowelShiftCipher(string s)
    {
        List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        string result = "";

        foreach (char c in s)
        {
            int index = vowels.IndexOf(c);

            if (index != -1)
            {
                result += vowels[(index + 1) % 5];
            }
            else
            {
                char next = (char)(c + 1);

                if (next > 'z')
                    next = 'a';

                while (vowels.Contains(next))
                {
                    next++;
                    if (next > 'z')
                        next = 'a';
                }

                result += next;
            }
        }

        return result;
    }

    static void Main()
    {
        string input = "abcdu";
        string output = VowelShiftCipher(input);
        Console.WriteLine(output);
    }
}