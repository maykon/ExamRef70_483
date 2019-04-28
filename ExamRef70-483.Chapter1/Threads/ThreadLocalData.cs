using System;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class ThreadLocalData
    {
        public static ThreadLocal<Random> RandomGenerator = new ThreadLocal<Random>(() => new Random(2));

        public static bool Run()
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });
            t1.Start();
            t2.Start();
            Thread.Sleep(6000);
            Console.WriteLine("Finished");
            return true;
        }

    }
}
