using System;

class Program
{
    static int[] Merge(int[] arr1, int[] arr2)
    {
        int m = arr1.Length;
        int n = arr2.Length;

        int[] arr3 = new int[m + n];

        int index = 0;
        int sum1 = 0, sum2 = 0;

        // Copy arr1
        for (int i = 0; i < m; i++)
        {
            arr3[index++] = arr1[i];
            sum1 += arr1[i];
        }

        // Copy arr2
        for (int i = 0; i < n; i++)
        {
            arr3[index++] = arr2[i];
            sum2 += arr2[i];
        }

        // Reverse merged array
        Array.Reverse(arr3);

        int avg1 = sum1 / m;
        int avg2 = sum2 / n;

        Console.WriteLine("Average of arr1: " + avg1);
        Console.WriteLine("Average of arr2: " + avg2);

        return arr3;
    }

    static void Main(string[] args)
    {
        int[] arr1 = { 71, 22, 31, 84, 58 };
        int[] arr2 = { 16, 25, 63, 40, 85 };

        int[] arr3 = Merge(arr1, arr2);

        Console.WriteLine("Merged & Reversed Array:");
        foreach (int x in arr3)
        {
            Console.Write(x + " ");
        }
    }
}

