using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class ThreadJoin
    {
        public static bool Run()
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                Console.WriteLine("Thread starting");
                Thread.Sleep(2000);
                Console.WriteLine("Thread done");
            });
            threadToWaitFor.Start();
            Console.WriteLine("Joining thread");
            threadToWaitFor.Join();
            Console.WriteLine("Finished thread");
            return true;
        }
    }
}
