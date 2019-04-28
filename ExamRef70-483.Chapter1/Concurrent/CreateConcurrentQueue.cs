using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ExamRef70_483.Chapter1.Concurrent
{
    public class CreateConcurrentQueue
    {
        public static bool Run()
        {
            var queue = new ConcurrentQueue<string>();
            queue.Enqueue("Rob");
            queue.Enqueue("Miles");
            if(queue.TryPeek(out string str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if(queue.TryDequeue(out str))
            {
                Console.WriteLine("Dequeue: {0}", str);
            }

            return true;
        }
    }
}
