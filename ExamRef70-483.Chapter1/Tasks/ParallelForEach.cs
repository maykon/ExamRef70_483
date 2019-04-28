using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ParallelForEach
    {

        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static bool Run()
        {
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item => WorkOnItem(item));

            Console.WriteLine("Press any key to end.");
            return true;
        }
    }
}
