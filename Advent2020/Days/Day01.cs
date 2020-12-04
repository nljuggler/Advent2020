using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day01 : IDay
    {
        private List<int> expenses => DayFileReader.Read(1).Select(int.Parse).ToList();
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;

        public string GetAssignment1()
        {
            var result = string.Empty;
            int rangeStart = 1;
            foreach (var s in expenses)
            {

                foreach (var i in expenses.GetRange(rangeStart, expenses.Count - rangeStart++))
                {
                    if (s + i == 2020)
                    {
                        result = $"{s} x {i} = {s * i}";
                        break;
                    }
                }
            }

            return result;
        }

        public string GetAssignment2()
        {
            var result = string.Empty;
            int outerRangeStart = 1;
            foreach (var s in expenses)
            {
                int innerRangeStart = outerRangeStart + 1;

                foreach (var i in expenses.GetRange(outerRangeStart, expenses.Count - outerRangeStart++))
                {
                    foreach (var j in expenses.GetRange(innerRangeStart, expenses.Count - innerRangeStart++))
                    {
                        if (s + i + j == 2020)
                        {
                            result = $"{s} x {i} x {j} = {s * i * j}";
                            goto Finished;

                        }
                    }
                }
            }
        Finished:
            return result;
        }

        private static IEnumerable<T> ReadValues<T>(string path)
        {
            string[] readText = File.ReadAllLines(path);
            foreach (var s in readText)
            {
                if (s is T t)
                {
                    yield return t;
                }
                else
                {
                    yield return (T)Convert.ChangeType(s, typeof(T));

                }
            }
        }
    }
}
