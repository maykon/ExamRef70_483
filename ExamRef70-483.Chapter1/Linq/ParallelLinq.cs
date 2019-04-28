using ExamRef70_483.Chapter1.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExamRef70_483.Chapter1.Linq
{
    public class ParallelLinq
    {
        IEnumerable<Person> _people;

        public ParallelLinq() => _people = new Person[]
                        {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charlie", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" },
                        };

        public ParallelLinq(IEnumerable<Person> people)
        {
            this._people = people;
        }

        public int Run()
        {
            var result = (from person in _people.AsParallel()
                         where person.City == "Seattle"
                          select person).ToList();
            foreach(var person in result)
                Console.WriteLine("Name: " + person.Name);

            return result.Count();
        }
    }
}
