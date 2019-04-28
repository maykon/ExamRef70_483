using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ParallelForResult
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
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int item, ParallelLoopState loopState) => {
                if (item == 200)
                    loopState.Stop();
                WorkOnItem(items[item]);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            return true;
        }
    }
}
