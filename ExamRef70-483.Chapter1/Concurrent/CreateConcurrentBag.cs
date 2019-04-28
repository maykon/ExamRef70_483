using System;
using System.Collections.Concurrent;
using System.Text;

namespace ExamRef70_483.Chapter1.Concurrent
{
    public class CreateConcurrentBag
    {
        public static bool Run()
        {
            var bag = new ConcurrentBag<string>();
            bag.Add("Rob");
            bag.Add("Miles");
            bag.Add("Hull");
            string str;
            if(bag.TryPeek(out str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if(bag.TryTake(out str))
            {
                Console.WriteLine("Take: {0}", str);
            }
            return true;
        }
    }
}
