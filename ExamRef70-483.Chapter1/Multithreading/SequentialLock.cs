using System;
using System.Collections.Generic;
using System.Text;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class SequentialLock
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
            Method1();
            Method2();
            Console.WriteLine("Methods complete.");
            return true;
        }

    }
}