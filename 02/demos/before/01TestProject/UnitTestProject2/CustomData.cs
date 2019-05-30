using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    public class CsvDataBaseAttribute : Attribute, ITestDataSource
    {
        private string FileName { get; }

        public CsvDataBaseAttribute(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            string[] csvLines = File.ReadAllLines(FileName);

            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);

                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);

            }

            return testCases;
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data == null)
            {
                return null;
            }

            return $"{methodInfo.Name} ({String.Join(",", data)})";
        }
    }
}