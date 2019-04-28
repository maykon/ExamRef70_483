using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class ThreadContext
    {

        static void DisplayThread(Thread t)
        {
            Console.WriteLine("Name: {0}", t.Name);
            Console.WriteLine("Culture: {0}", t.CurrentCulture);
            Console.WriteLine("Priority: {0}", t.Priority);
            Console.WriteLine("Context: {0}", t.ExecutionContext);
            Console.WriteLine("IsBackground?: {0}", t.IsBackground);
            Console.WriteLine("IsPool?: {0}", t.IsThreadPoolThread);
        }

        public static bool Run()
        {
            Thread.CurrentThread.Name = "Main Thread";

            Thread test = new Thread(() =>
            {
                DisplayThread(Thread.CurrentThread);
                Thread.Sleep(100);
            })
            { IsBackground = false, Priority = ThreadPriority.Highest };
            test.Name = "Test";
            test.Start();
            test.Join();

            Console.WriteLine();
            DisplayThread(Thread.CurrentThread);

            return true;
        }
    }
}
