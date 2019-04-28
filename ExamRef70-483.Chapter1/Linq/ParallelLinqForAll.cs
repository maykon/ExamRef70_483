using ExamRef70_483.Chapter1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamRef70_483.Chapter1.Linq
{
    public class ParallelLinqForAll
    {
        IEnumerable<Person> _people;

        public ParallelLinqForAll(IEnumerable<Person> people)
        {
            this._people = people;
        }

        public int Run()
        {
            ParallelQuery<Person> result = from person in _people.AsParallel()
                          where person.City == "Seattle"
                          select person;
            result.ForAll(person => Console.WriteLine("Name: " + person.Name));

            return result.Count();
        }
    }
}
