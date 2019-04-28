using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef70_483.Chapter1.Tasks
{
    public class ContinuationTaskOptions
    {
        static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
            //throw new ArgumentException("ERROR");
        }

        static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
            //throw new ArgumentException("ERROR");
        }

        static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Exception");
        }

        public static bool Run()
        {
            try { 
                Task task = Task.Run(() => HelloTask());
                task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);
                task.Wait();
                Thread.Sleep(3000);
            }catch(Exception e){
                Thread.Sleep(2000);
            }
            return true;
        }
    }
}
