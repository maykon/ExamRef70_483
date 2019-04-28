using System;
using System.Collections.Concurrent;
using System.Text;

namespace ExamRef70_483.Chapter1.Concurrent
{
    public class CreateConcurrentDictionary
    {
        public static bool Run()
        {
            var ages = new ConcurrentDictionary<string, int>();
            if(ages.TryAdd("Rob", 21))
            {
                Console.WriteLine("Rob added successfully.");
            }
            Console.WriteLine("Rob's age: {0}", ages["Rob"]);
            if(ages.TryUpdate("Rob", 22, 21)){
                Console.WriteLine("Age updated successfully");
            }
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
            Console.WriteLine("Rob's age updated to: {0}", ages.AddOrUpdate("Rob", 1, (name, age) => age = age+1));
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
            return true;
        }
    }
}
