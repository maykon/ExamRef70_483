using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class MonitorTaskSum
    {
        private static readonly object sharedTotalLock = new object();
        private static long sharedTotal = 0;
        private static readonly int[] items = Enumerable.Range(0, 50000001).ToArray();

        private static void AddRangeOfValues(int start, int end)
        {
            long subTotal = 0;
            while (start < end)
            {
                subTotal += items[start];
                start++;
            }
            Monitor.Enter(sharedTotalLock);
            try
            {
                sharedTotal = sharedTotal + subTotal;
            }
            finally
            {
                Monitor.Exit(sharedTotalLock);
            }            
        }

        public static bool Run()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 100;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > items.Length)
                    rangeEnd = items.Length;

                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => AddRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Total is: {0}", sharedTotal);
            return true;
        }
    }
}
