using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class CancelTask
    {
        static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private static void Clock()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }
        }

        public static bool Run()
        {
            Task.Run(() => Clock());
            Console.WriteLine("Waiting 3 seconds to stop the clock");
            Thread.Sleep(3000);            
            cancellationTokenSource.Cancel();
            Console.WriteLine("Clock stopped");            
            return true;
        }
    }
}
