using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class TaskReturnValue
    {
        static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }

        public static int Run()
        {
            // http://blog.stephencleary.com/2013/08/startnew-is-dangerous.html
            //Task<int> newTask = Task.Factory.StartNew(() => CalculateResult(),
            //    CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
            //Task<int> newTask = Task.Factory.StartNew(() => CalculateResult(),
            //    TaskCreationOptions.LongRunning);

            Task<int> newTask = Task.Run(() => CalculateResult());
            return newTask.Result;
        }
    }
}
