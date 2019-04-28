using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class CancelTaskException
    {
        static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
      
        private static void Clock(CancellationToken cancellationToken)
        {
            int tickCount = 0;
            while (!cancellationTokenSource.IsCancellationRequested && tickCount < 20)
            {
                tickCount++;
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }
            cancellationToken.ThrowIfCancellationRequested();
        }

        public static bool Run()
        {
            Task clock = Task.Run(() => Clock(cancellationTokenSource.Token));
            Console.WriteLine("Waiting 3 seconds to stop the clock");
            Thread.Sleep(3000);
            if (clock.IsCompleted)
            {
                Console.WriteLine("Clock task completed");
                return true;
            }

            try
            {
                cancellationTokenSource.Cancel();
                clock.Wait();
            }catch(AggregateException ex)
            {
                Console.WriteLine("Clock stopped: {0}", ex.InnerExceptions[0].ToString());
            }
            return true;
        }
    }
}
