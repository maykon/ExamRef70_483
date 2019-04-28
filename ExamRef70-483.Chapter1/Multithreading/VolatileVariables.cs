using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Multithreading
{
    public class VolatileVariables
    {
        //private static int volInt;
        private static volatile int volInt;

        private static void Execute()
        {
            int x;
            int y = 0;
            x = 99;
            y = y + 1;
            Console.WriteLine("The answer is: {0}", x);
        }

        private static void ExecuteTask(int num)
        {
            Console.WriteLine("The initial value task {0} is: {1}", num, volInt);
            int y = 0;
            volInt = num;
            y = y + 1;
            Console.WriteLine("The final value task {0} is: {1}", num, volInt);
        }

        public static bool Run()
        {
            Execute();
            Task t1 = Task.Run(() => ExecuteTask(99));
            Task t2 = Task.Run(() => ExecuteTask(98));
            Task t3 = Task.Run(() => ExecuteTask(97));
            Task t4 = Task.Run(() => ExecuteTask(96));
            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("The final answer is: {0}", volInt);
            return true;
        }
    }
}
