using ExamRef70_483.Chapter1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamRef70_483.Chapter1.Linq
{
    public class ParallelLinqAggregateException
    {
        IEnumerable<Person> _people;

        public ParallelLinqAggregateException(IEnumerable<Person> people)
        {
            this._people = people;
        }

        private bool CheckCityName(string city)
        {
            if (city == string.Empty)
                throw new ArgumentException(city);

            return city == "Seattle";
        }

        void PrintPerson(Person person)
        {
            Console.WriteLine("Name: " + person.Name);
            new ArgumentException(person.Name);
        }

        public int Run()
        {
            var total = 0;
            var result = from person in _people.AsParallel()
                         where CheckCityName(person.City)
                         select person;

            try
            {
                result.ForAll(person => PrintPerson(person));
                total = result.Count();
            }
            catch(AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            }catch(ArgumentException ae)
            {
                Console.WriteLine("Argumento inválido.");
            }

            return total;
        }
    }
}
