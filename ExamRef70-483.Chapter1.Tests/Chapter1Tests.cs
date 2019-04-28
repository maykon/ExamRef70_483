using ExamRef70_483.Chapter1.Concurrent;
using ExamRef70_483.Chapter1.Linq;
using ExamRef70_483.Chapter1.Multithreading;
using ExamRef70_483.Chapter1.Tasks;
using ExamRef70_483.Chapter1.Tests.utils;
using ExamRef70_483.Chapter1.Threads;
using ExamRef70_483.Chapter1.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExamRef70_483.Chapter1.Tests
{
    #region Tasks
    [TestClass]
    public class Chapter1Tests
    {
        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]        
        [TestMethod]
        public void TestParallelInvoke()
        {
            Assert.IsTrue(ParallelInvoke.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestParallelForEach()
        {
            Assert.IsTrue(ParallelForEach.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestParallelFor()
        {
            Assert.IsTrue(ParallelFor.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestParallelForResult()
        {
            Assert.IsTrue(ParallelForResult.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestParallelForEachResult()
        {
            Assert.IsTrue(ParallelForEachResult.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestCreateTask()
        {
            Assert.IsTrue(CreateTask.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestRunTask()
        {
            Assert.IsTrue(RunTask.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestTaskReturnValue()
        {
            Assert.AreEqual<int>(TaskReturnValue.Run(), 99);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestTaskWaitAll()
        {
            Assert.IsTrue(TaskWaitAll.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestContinuationTask()
        {
            Assert.IsTrue(ContinuationTask.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestContinuationTaskOptions()
        {
            Assert.IsTrue(ContinuationTaskOptions.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Tasks")]
        [TestMethod]
        public void TestChildTask()
        {
            Assert.IsTrue(ChildTask.Run());
        }
        #endregion

        #region LINQ
        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [DynamicData(nameof(PersonTestData.TestData), typeof(PersonTestData))]
        public void TestParallelLinq(IEnumerable<Person> people)
        {
            var linq = new ParallelLinq(people);
            Assert.AreEqual<int>(linq.Run(), 4);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [PersonCsvDataSource("People.csv")]
        public void TestParallelLinqOptions(IEnumerable<Person> people)
        {
            var linq = new ParallelLinqOptions(people);
            Assert.AreEqual<int>(linq.Run(), 4);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [PersonCsvDataSource("People.csv")]
        public void TestParallelLinqOrdered(IEnumerable<Person> people)
        {
            var linq = new ParallelLinqOrdered(people);
            Assert.AreEqual<int>(linq.Run(), 4);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [PersonCsvDataSource("People.csv")]
        public void TestParallelLinqSequential(IEnumerable<Person> people)
        {
            var linq = new ParallelLinqSequential(people);
            Assert.AreEqual<int>(linq.Run(), 4);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [PersonCsvDataSource("People.csv")]
        public void TestParallelLinqForAll(IEnumerable<Person> people)
        {
            var linq = new ParallelLinqForAll(people);
            Assert.AreEqual<int>(linq.Run(), 4);
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("LINQ")]
        [DataTestMethod]
        [PersonCsvDataSource("PeopleException.csv")]
        public void TestParallelLinqAggregateException(IEnumerable<Person> people)
        {
            var linq = new ParallelLinqAggregateException(people);
            Assert.AreEqual<int>(linq.Run(), 0);
        }
        #endregion

        #region Thread
        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestCreateThread()
        {
            Assert.IsTrue(CreateThread.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestCreateThreadStart()
        {
            Assert.IsTrue(CreateThreadStart.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestThreadLambda()
        {
            Assert.IsTrue(ThreadLambda.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestCreateThreadData()
        {
            Assert.IsTrue(CreateThreadData.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestCreateThreadDataLambda()
        {
            Assert.IsTrue(CreateThreadDataLambda.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestAbortingThread()
        {
            Assert.IsTrue(AbortingThread.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestThreadJoin()
        {
            Assert.IsTrue(ThreadJoin.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestThreadLocalData()
        {
            Assert.IsTrue(ThreadLocalData.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestThreadContext()
        {
            Assert.IsTrue(ThreadContext.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Thread")]
        [TestMethod]
        public void TestCreateThreadPool()
        {
            Assert.IsTrue(CreateThreadPool.Run());
        }
        #endregion

        #region Concurrent
        [TestCategory("Skill 1.1")]
        [TestCategory("Concurrent")]
        [TestMethod]
        public void TestCreateBlockingCollection()
        {
            Assert.IsTrue(CreateBlockingCollection.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Concurrent")]
        [TestMethod]
        public void TestCreateConcurrentQueue()
        {
            Assert.IsTrue(CreateConcurrentQueue.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Concurrent")]
        [TestMethod]
        public void TestCreateConcurrentStack()
        {
            Assert.IsTrue(CreateConcurrentStack.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Concurrent")]
        [TestMethod]
        public void TestCreateConcurrentBag()
        {
            Assert.IsTrue(CreateConcurrentBag.Run());
        }

        [TestCategory("Skill 1.1")]
        [TestCategory("Concurrent")]
        [TestMethod]
        public void TestCreateConcurrentDictionary()
        {
            Assert.IsTrue(CreateConcurrentDictionary.Run());
        }
        #endregion

        #region MultiThreading
        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestSingleTaskSum()
        {
            Assert.IsTrue(SingleTaskSum.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestBadTaskSum()
        {
            Assert.IsTrue(BadTaskSum.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestGoodTaskSum()
        {
            Assert.IsTrue(GoodTaskSum.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestMonitorTaskSum()
        {
            Assert.IsTrue(MonitorTaskSum.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestSequentialLock()
        {
            Assert.IsTrue(SequentialLock.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod, Ignore]
        public void TestDeadLockTask()
        {
            Assert.IsTrue(DeadLockTask.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestInterlockedSum()
        {
            Assert.IsTrue(InterlockedSum.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestGoodSearchArray()
        {
            Assert.IsTrue(GoodSearchArray.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestVolatileVariables()
        {
            Assert.IsTrue(VolatileVariables.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestCancelTask()
        {
            Assert.IsTrue(CancelTask.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestCancelTaskException()
        {
            Assert.IsTrue(CancelTaskException.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestCounterUnsafe()
        {
            Assert.IsTrue(CounterUnsafe.Run());
        }

        [TestCategory("Skill 1.2")]
        [TestCategory("Multithreading")]
        [TestMethod]
        public void TestCustomerSafeParams()
        {
            Assert.IsTrue(CustomerSafeParams.Run());
        }


        #endregion
    }
}
