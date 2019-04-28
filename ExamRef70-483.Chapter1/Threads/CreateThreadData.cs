using System;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class CreateThreadData
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }

        public static bool Run()
        {
            var ps = new ParameterizedThreadStart(WorkOnData);
            var thread = new Thread(ps);
            thread.Start(99);
            return true;
        }
    }
}
