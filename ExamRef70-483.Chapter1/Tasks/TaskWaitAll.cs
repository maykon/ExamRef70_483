using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class TaskWaitAll
    {
        static void DoWork(int item)
        {
            Console.WriteLine("Task {0} starting", item);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} finished", item);
        }

        public static bool Run()
        {
            Task[] _tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int taskNum = i;
                _tasks[i] = Task.Run(() => DoWork(taskNum));
            }
            Task.WaitAll(_tasks);
            return true;
        }
    }
}
