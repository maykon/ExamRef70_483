using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class CounterUnsafe
    {
        private int totalValue = 0;
        public void IncreaseCounter(int total, int amount)
        {
            totalValue = total + amount;
        }

        public int Total {
            get { return totalValue; }
        }

        public static bool Run()
        {
            CounterUnsafe counter = new CounterUnsafe();
            Task t1 = Task.Run(() => counter.IncreaseCounter(counter.Total, 4));
            Task t2 = Task.Run(() => counter.IncreaseCounter(counter.Total, 3));
            Task t3 = Task.Run(() => counter.IncreaseCounter(counter.Total, 2));
            Task t4 = Task.Run(() => counter.IncreaseCounter(counter.Total, 1));
            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("Total is: {0}", counter.Total);
            return true;
        }
    }
}
