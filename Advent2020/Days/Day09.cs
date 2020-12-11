using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day09 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<long> Lines => DayFileReader.Read(9).Select(long.Parse).ToList();
        public string GetAssignment1()
        {
            return $"The invalid number is: {FindInvalidNumber()}";
        }

        public string GetAssignment2()
        {
            var stopwatch = Stopwatch.StartNew();
            var invalidNumber = FindInvalidNumber();
            for (int i = 0; i < Lines.Count; i++)
            {
                var result = new List<long> {Lines[i]};
                for (int j = i + 1; j < Lines.Count; j++)
                {
                    result.Add(Lines[j]);
                    if (result.Sum() == invalidNumber)
                    {
                        Console.WriteLine(stopwatch.Elapsed);
                        return $"{result.Min()} + {result.Max()} = {result.Min() + result.Max()}";
                    }

                    if (result.Sum() > invalidNumber)
                    {
                        break;
                    }
                }
            }

            return "something went horribly wrong!";
        }

        private long FindInvalidNumber()
        {
            for (int i = 25; i < Lines.Count; i++)
            {
                var checkList = Lines.GetRange(i - 25, 25);
                if (!checkList.Any(item => checkList.Contains(Lines[i] - item)))
                {
                    return Lines[i];
                }
            }
            return -1;
        }
    }
}
