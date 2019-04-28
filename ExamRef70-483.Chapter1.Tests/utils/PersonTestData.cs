using ExamRef70_483.Chapter1.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamRef70_483.Chapter1.Tests.utils
{
    public class PersonTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                var people = new List<Person>();
                string[] csvLines = File.ReadAllLines("People.csv");
                foreach (var line in csvLines)
                {
                    IEnumerable<string> values = line.Split(",");
                    people.Add(new Person { Name = values.ElementAt<string>(0), City = values.ElementAt<string>(1) });
                }
                yield return new object[] { people };
            }
        }
    }
}
