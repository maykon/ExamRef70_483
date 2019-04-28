using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class CreateThreadPool
    {

        static void DoWork(object state)
        {
            Console.WriteLine("Doing work: {0}", state);
            Thread.Sleep(100);
            Console.WriteLine("Work finished: {0}", state);
        }

        public static bool Run()
        {
            for (int i = 0; i < 50; i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
            }
            Thread.Sleep(5000);
            Console.WriteLine("Finished thread pool");
            return true;
        }
    }
}
