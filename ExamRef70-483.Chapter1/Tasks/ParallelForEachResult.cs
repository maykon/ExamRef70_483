using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ParallelForEachResult
    {
        static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static bool Run()
        {
            var items = Enumerable.Range(0, 500);
            ParallelLoopResult result = Parallel.ForEach(items, (int item, ParallelLoopState loopState) => {
                if (item == 200)
                    loopState.Stop();
                WorkOnItem(item);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            long lowItem = result.LowestBreakIteration ?? default(long);
            Console.WriteLine("Items: " + lowItem);
            return true;
        }
    }
}
