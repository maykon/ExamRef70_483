using ExamRef70_483.Chapter1.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExamRef70_483.Chapter1.Tests.utils
{
    public class PersonCsvDataSource : Attribute, ITestDataSource
    {
        public string FileName { get; }

        public PersonCsvDataSource(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var people = new List<Person>();
            string[] csvLines = File.ReadAllLines(FileName);
            foreach (var line in csvLines)
            {
                IEnumerable<string> values = line.Split(",");
                people.Add(new Person { Name = values.ElementAt<string>(0), City = values.ElementAt<string>(1) });
            }
            yield return new object[] { people };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data == null)
                return null;

            return $"{methodInfo.Name} - ({string.Join(",", data)})";
        }
    }
}
