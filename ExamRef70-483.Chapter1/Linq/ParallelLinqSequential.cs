using ExamRef70_483.Chapter1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamRef70_483.Chapter1.Linq
{
    public class ParallelLinqSequential
    {
        IEnumerable<Person> _people;

        public ParallelLinqSequential(IEnumerable<Person> people)
        {
            this._people = people;
        }

        public int Run()
        {
            var result = (from person in _people.AsParallel()
                         where person.City == "Seattle"
                          orderby person.Name
                         select new
                         {
                             person.Name                             
                         }).AsSequential().Take(4);
            foreach (var person in result)
                Console.WriteLine("Name: " + person.Name);

            return result.Count();
        }
    }
}
