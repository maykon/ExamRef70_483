using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ChildTask
    {
        static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child {0} finished", state);
        }

        public static bool Run()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNum = i;
                    Task.Factory.StartNew((x) => DoChild(x), taskNum, TaskCreationOptions.AttachedToParent);
                }
            });
            parent.Wait();

            /* 
            // TaskCreationOptions.DenyChildAttach -> Childs run detached
            var parent = Task.Run(() =>
            {
               Console.WriteLine("Parent starts");
               for (int i = 0; i < 10; i++)
               {
                   int taskNum = i;
                   Task.Factory.StartNew((x) => DoChild(x), taskNum, TaskCreationOptions.AttachedToParent);
               }
            });
            parent.Wait(); */

            return true;
        }
    }
}
