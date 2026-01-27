namespace Assesment2
{
    internal class Program
    {
        //static bool Checkpali(string t)
        //{
        //     int j=t.Length-1;
        //    int sum = 0;
        //    int p = t.Length / 2;
        //    for(int i=0;i<p; i++)
        //    {
               
        //        if(t[i] == t[j])
        //        {
        //            sum++;
        //        }
        //        j--;
        //    }
        //    if (sum == p)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        static void Main(string[] args) {
            //{
            //    string t =  "abcdcba" ;
            //    bool m = Checkpali(t);
            //    Console.WriteLine(m);
            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int k = 1; k <= Math.Min(i,10-1);k++)
            //    {
            //        Console.Write(k);
            //    }
            //    Console.WriteLine();
            //}
            //    //for (int k = 1; k<= i; k++)
            //    //{

            //    //  Console.Write(k);

            //    //}
            int m = 5;
            for (int i = 0; i <m; i++)
            {
                for(int j = 0; j <m; j++)
                {
                    if (i == j || (i + j) == m-1 ) 
                    {
                        Console.Write("1");
                    }
                    
                  else
                        Console.Write("0");
                }
                Console.WriteLine();
            }

             
        }
    }
}
