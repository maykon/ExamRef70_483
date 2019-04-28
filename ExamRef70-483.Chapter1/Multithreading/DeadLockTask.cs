using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class DeadLockTask
    {
        static object lock1 = new object();
        static object lock2 = new object();
        static void Method1()
        {
            lock (lock1)
            {
                Console.WriteLine("Method 1 got lock 1");
                Console.WriteLine("Method 1 waiting for lock 1");
                lock (lock2)
                {
                    Console.WriteLine("Method 1 got lock 2");
                }
                Console.WriteLine("Method 1 released lock 2");
            }
            Console.WriteLine("Method 1 released lock 1");
        }

        static void Method2()
        {
            lock (lock2)
            {
                Console.WriteLine("Method 2 got lock 2");
                Console.WriteLine("Method 2 waiting for lock 1");
                lock (lock1)
                {
                    Console.WriteLine("Method 2 got lock 1");
                }
                Console.WriteLine("Method 2 released lock 1");
            }
            Console.WriteLine("Method 2 released lock 2");
        }

        public static bool Run()
        {
            Task t1 = Task.Run(() => Method1());
            Task t2 = Task.Run(() => Method2());
            Console.WriteLine("waiting for Task 2");
            t2.Wait();
            Console.WriteLine("Methods complete.");
            return true;
        }
    }
}
