using System;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class CreateThread
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        public static bool Run()
        {
            Thread thread = new Thread(ThreadHello);
            thread.Start();
            return true;
        }
    }
}
