using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ContinuationTask
    {
        static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        static void WorldTask(Task t)
        {
            Thread.Sleep(1000);
            Console.WriteLine(t);
            Console.WriteLine("World");
        }

        static void TestTask()
        {
            Thread.Sleep(500);
            Console.WriteLine("Test");
        }

        public static bool Run()
        {
            //Action<Task> teste = WorldTask;

            Task task = Task.Run(() => HelloTask());
            task.ContinueWith(t => WorldTask(t))
            .ContinueWith( prevTask => TestTask());

            task.Wait();
            Thread.Sleep(2000);
            return true;
        }
    }
}
