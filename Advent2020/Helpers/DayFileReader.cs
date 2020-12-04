using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Helpers
{
    public static class DayFileReader
    {
        public static List<string> Read(int day)
        {
            return File.ReadAllLines($"../.././Data/day{day}.txt").ToList();
        }
    }
}
