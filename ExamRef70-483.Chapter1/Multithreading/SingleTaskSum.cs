using System;
using System.Linq;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class SingleTaskSum
    {
        private static readonly int[] items = Enumerable.Range(0, 50000001).ToArray();

        public static bool Run()
        {
            long total = 0;
            for (int i = 0; i < items.Length; i++)
                total += items[i];

            Console.WriteLine("Total is: {0}", total);
            return true;
        }
    }
}
