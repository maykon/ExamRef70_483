using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Concurrent
{
    public class CreateBlockingCollection
    {
        public static bool Run()
        {
            //var data = new BlockingCollection<int>(5);
            var data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);
            Task.Run(() => {
                for (int i = 0; i < 11; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added successfully.", i);
                }
                data.CompleteAdding();
            });
            Thread.Sleep(2000);

            Console.WriteLine("Reading collection");

            Task.Run(() => {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken successfuly.", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });
            Thread.Sleep(2000);
            return true;
        }
    }
}
