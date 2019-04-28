using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamRef70_483.Chapter1.Threads
{
    class Gambit
    {
        public int Test { get; set; }
    }

    public class CreateThreadDataLambda
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }

        static void WorkOnClass(object data)
        {
            Console.WriteLine("Working on class: {0}", data);
            var gambit = (Gambit)data;
            Console.WriteLine("Working on Gambit: {0}", gambit.Test);
            Thread.Sleep(1000);
        }

        public static bool Run()
        {
            var thread = new Thread(data => WorkOnData(data));
            thread.Start(99);
            thread.Join();

            var thread2 = new Thread(data => WorkOnClass(data));
            thread2.Start(new Gambit() { Test = 1 });
            thread2.Join();

            /*var thread3 = new Thread(data => WorkOnClass(data));
            thread3.Start(new object());
            thread3.Join();

            var thread4 = new Thread(data => WorkOnClass(data));
            thread3.Start(99); */
            return true;
        }
    }
}
