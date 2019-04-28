using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class ThreadLambda
    {
        public static bool Run()
        {
            var thread = new Thread(() =>
            {
                Console.WriteLine("Hello from thread");
                Thread.Sleep(2000);
            });
            thread.Start();
            Console.WriteLine("Finished thread");
            return true;
        }
    }
}
