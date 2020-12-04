using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent2020.Days
{
    class Day02 : IDay
    {
        private string _assignment1Result;
        private string _assignment2Result;
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;

        public Day02()
        {
            Process();
        }
        
        public string GetAssignment1()
        {
            return _assignment1Result;
        }

        public string GetAssignment2()
        {
            return _assignment2Result;
        }

        private void Process()
        {
            int validPasswordsAssignment1 = 0;
            int validPasswordsAssignment2 = 0;
            string passwords = File.ReadAllText(@"c:\Users\jeko\source\repos\Advent2020\Advent2020\Data\day2.txt");
            Regex passwordRegex = new Regex("(\\d+)\\-(\\d+) ([a-z]): ([a-z]+)");

            foreach (Match passwordLine in passwordRegex.Matches(passwords))
            {
                char requiredLetter = Convert.ToChar(passwordLine.Groups[3].Value);
                int minCount = int.Parse(passwordLine.Groups[1].Value);
                int maxCount = int.Parse(passwordLine.Groups[2].Value);
                string password = passwordLine.Groups[4].ToString();

                // Assignment 1
                int count = new Regex(requiredLetter.ToString()).Matches(password).Count;
                if (count >= minCount && count <= maxCount)
                {
                    validPasswordsAssignment1++;
                }

                // Assignment 2
                if (password[minCount - 1] == requiredLetter ^ password[maxCount - 1] == requiredLetter)
                {
                    validPasswordsAssignment2++;
                }
            }
            _assignment1Result = $"{validPasswordsAssignment1} valid passwords found for assignment 1";
            _assignment2Result = $"{validPasswordsAssignment2} valid passwords found for assignment 2";
        }
    }
}
