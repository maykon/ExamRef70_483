using System;
using System.Threading;
using System.Threading.Tasks;


namespace ExamRef70_483.Chapter1.Tasks
{
    public class ParallelInvoke
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting.");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending.");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting.");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending.");
        }

        public static bool Run()
        {
            Parallel.Invoke(() => Task1(), () => Task2());
            return true;
        }
    }
}
