using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ParallelFor
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static bool Run()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, items.Length, item => WorkOnItem(items[item]));
            return true;
        }
    }
}
