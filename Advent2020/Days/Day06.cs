using System.Collections.Generic;
using System.Linq;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day06 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(6);
        public string GetAssignment1()
        {
            return $"The sum of the first counts is: {GetGroups().Sum(grp => grp.Where(c => c != ';').Distinct().Count())}";
        }

        public string GetAssignment2()
        {
            var result = GetGroups().Sum(grp => grp.Split(';').Select(s => s.ToCharArray()).Aggregate((x, y) => x.Intersect(y).ToArray()).Length);
            return $"The sum of the second counts is: {result}";
        }

        private IEnumerable<string> GetGroups()
        {
            var group = string.Empty;
            for (var index = 0; index < Lines.Count; index++)
            {
                var line = Lines[index];
                group += $"{line};";
                if (index == Lines.Count - 1 || string.IsNullOrEmpty(Lines[index + 1]))
                {
                    yield return group.Substring(0,group.Length - 1);
                    group = string.Empty;
                    index++;
                }
            }
        }
    }
}
