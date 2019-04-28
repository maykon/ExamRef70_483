using System;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class CreateThreadStart
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        public static bool Run()
        {
            ThreadStart ts = new ThreadStart(ThreadHello);
            Thread thread = new Thread(ts);
            thread.Start();
            return true;
        }
    }
}
