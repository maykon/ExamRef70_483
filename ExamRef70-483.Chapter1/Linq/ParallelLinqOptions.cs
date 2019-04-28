using ExamRef70_483.Chapter1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamRef70_483.Chapter1.Linq
{
    public class ParallelLinqOptions
    {
        IEnumerable<Person> _people;

        public ParallelLinqOptions(IEnumerable<Person> people)
        {
            this._people = people;
        }

        public int Run()
        {
            var result = from person in _people.AsParallel()
                                                .WithDegreeOfParallelism(4)
                                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle"
                         select person;
            foreach (var person in result)
                Console.WriteLine("Name: " + person.Name);

            return result.Count();
        }

    }
}
