using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day04 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(4);
        private readonly List<string> _passportList;

        public Day04()
        {
            _passportList = GetPassports().ToList();
        }

        public string GetAssignment1()
        {
            int numValidPassports = _passportList.Count(ContainsAllRequiredFields);
            return $"{numValidPassports} passports with all required fields found.";
        }

        public string GetAssignment2()
        {
            var validPassports =  _passportList.Where(ContainsAllRequiredFields);
            int numValidPassports = validPassports.Count(IsValid);
            return $"{numValidPassports} valid passports found.";
        }

        private IEnumerable<string> GetPassports()
        {
            var passport = string.Empty;
            for (var index = 0; index < Lines.Count; index++)
            {
                var line = Lines[index];
                passport += $" {line}";
                if (index == Lines.Count - 1 || string.IsNullOrEmpty(Lines[index + 1]))
                {
                    yield return passport;
                    passport = string.Empty;
                }
            }
        }

        private bool IsValid(string passport)
        {
            var regex = new Regex(@"^.*(?=.*\bbyr:(?<byr>\d{4})\b)(?=.*\biyr:(?<iyr>\d{4})\b)(?=.*\beyr:(?<eyr>\d{4})\b)(?=.*\bhgt:(?<hgt>(\d{3}(?=cm\b)|\d{2}(?=in\b))))(?=.*\bhcl:(?<hcl>#[0-9a-f]{6})\b)(?=.*\becl:(?<ecl>(amb|blu|brn|gry|grn|hzl|oth))\b)(?=.*\bpid:(?<pid>\d{9})\b).*$");
            var matches = regex.Matches(passport);
            if (matches.Count == 0)
            {
                return false;
            }

            var match = matches[0];

            var byr = int.Parse(match.Groups["byr"].Value);
            if (byr < 1920 || byr > 2002) return false;

            var iyr = int.Parse(match.Groups["iyr"].Value);
            if (iyr < 2010 || iyr > 2020) return false;

            var eyr = int.Parse(match.Groups["eyr"].Value);
            if (eyr < 2020 || eyr > 2030) return false;

            var hgt = int.Parse(match.Groups["hgt"].Value);
            if (hgt < 100 && (hgt < 59 || hgt > 76) || hgt > 100 && (hgt < 150 || hgt > 193)) return false;

            return true;
        }

        private bool ContainsAllRequiredFields(string passport)
        {
            var requiredFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            return requiredFields.All(requiredField => passport.Contains(requiredField + ":"));
        }
    }
} 