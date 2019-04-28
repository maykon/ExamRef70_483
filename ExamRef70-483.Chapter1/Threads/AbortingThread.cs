using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    public class AbortingThread
    {
        static bool tickRunning;

        public static bool Run()
        {
            tickRunning = true;
            var tickThread = new Thread(() =>
            {
                while (tickRunning)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);

                }
            });
            tickThread.Start();           
            Thread.Sleep(2000);
            Console.WriteLine("Stopping a thread");
            tickRunning = false;
            // Throw System.PlatformNotSupportedException
            //tickThread.Abort();
            Thread.Sleep(2000);            
            Console.WriteLine("Finished thread");

            return true;
        }
    }
}
