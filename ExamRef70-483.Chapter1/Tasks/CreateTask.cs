using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class CreateTask
    {
        static void DoWork()
        {            
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        public static bool Run()
        {
            //Action act = DoWork;
            //Task newTask = new Task(act);
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            Console.WriteLine("Finished task");
            newTask.Wait();
            Console.WriteLine("Completed task");
            return true;
        }
    }
}
