using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class RunTask
    {
        static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        public static bool Run()
        {
            Task newTask = Task.Run(() => DoWork());
            newTask.Wait();
            return true;
        }
    }
}
