using System.Collections.Generic;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day03 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(3);
        
        public string GetAssignment1()
        {
            return $"You hit {CountTrees(Lines, 3, 1)} trees on your way down!";
        }


        public string GetAssignment2()
        {var slopes = new[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };

            double hitSum = 1;

            for (int i = 0; i < slopes.Length / slopes.Rank; i++)
            {
                hitSum *= CountTrees(Lines, slopes[i, 0], slopes[i, 1]);

            }
            return $"The sum of a trees hit for the different slopes is {hitSum}!";
        }
        private static int CountTrees(List<string> lines, int right, int down)
        {
            var currentPosition = -right;
            var treesHit = 0;

            for (int i = 0; i < lines.Count; i = i + down)
            {
                currentPosition += right;
                currentPosition = currentPosition % lines[i].Length;
                if (lines[i][currentPosition] == '#')
                {
                    treesHit++;
                }
            }

            return treesHit;
        }
    }
}
