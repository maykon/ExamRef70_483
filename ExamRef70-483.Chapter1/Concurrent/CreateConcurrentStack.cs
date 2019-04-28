using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ExamRef70_483.Chapter1.Concurrent
{
    public class CreateConcurrentStack
    {
        public static bool Run()
        {
            var stack = new ConcurrentStack<string>();
            stack.Push("Rob");
            stack.Push("Miles");
            string[] items = { "teste", "teste2"};
            stack.PushRange(items);
            if (stack.TryPeek(out string str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if (stack.TryPop(out str))
            {
                Console.WriteLine("Pop: {0}", str);
            }
            return true;
        }
    }
}
