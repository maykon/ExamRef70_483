using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class GoodSearchArray
    {
        private const int locked = 1;
        private const int unLocked = 0;

        private const int MAX_ITEMS = 50000001;
        private static long biggestNum = 0;
        private static long smallestNum = MAX_ITEMS;
        
        private static readonly int[] items = new int[MAX_ITEMS];
        
        private static void ComputeRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                var arrValue = items[start];
                if (arrValue < smallestNum)
                    Interlocked.Exchange(ref smallestNum, arrValue);                    
                if (arrValue > biggestNum)
                    Interlocked.Exchange(ref biggestNum, arrValue);
                start++;
            }            
        }

        public static bool Run()
        {
            CreateArrayRandom();
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

                tasks.Add(Task.Run(() => ComputeRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Searching array data...");
            Console.WriteLine("Small data searched: {0}", smallestNum);
            Console.WriteLine("Big data searched: {0}", biggestNum);
            return true;
        }

        private static void CreateArrayRandom()
        {
            var random = new Random();
            var small = MAX_ITEMS;
            var big = 0;
            Parallel.For(0, MAX_ITEMS, item => {
                var arrValue = random.Next(0, MAX_ITEMS);
                items[item] = arrValue;
                if (arrValue < small)
                    small = arrValue;
                if (arrValue > big)
                    big = arrValue;
            });
            Console.WriteLine("Creating array data...");
            Console.WriteLine("Small data created: {0}", small);
            Console.WriteLine("Big data created: {0}", big);
        }
    }
}


