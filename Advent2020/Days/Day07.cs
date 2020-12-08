using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day07 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(7);
        public string GetAssignment1()
        {
            var containingBags = new HashSet<Bag>();
            CountBagsContainingColor(GetBagList(), "shiny gold", ref containingBags);
            return $"{containingBags.Count} bags can contain a shiny gold bag.";
        }

        public string GetAssignment2()
        {
            var containedBags = CountContainingBagsInColor("shiny gold");

            return $"There are {containedBags} inside a shiny gold bag.";
        }

        private List<Bag> GetBagList()
        {
            var regex = new Regex(@"(?=(?<count>(\d)) (?<color>[a-z ]+?(?= bag)))");
            return Lines.Select(line => new Bag()
            {
                Color = line.Substring(0, line.IndexOf("bags", StringComparison.CurrentCulture) - 1),
                Contains = (from Match match in regex.Matches(line) select new Bag() { Amount = Convert.ToInt32(match.Groups["count"].Value), Color = match.Groups["color"].Value }).ToList()
            }).ToList();
        }

        private HashSet<Bag> CountBagsContainingColor(List<Bag> bags, string bagColor, ref HashSet<Bag> containingBags)
        {
            foreach (var bag in bags.Where(b => b.Contains.Any(b2 => b2.Color == bagColor)))
            {
                containingBags.Add(bag);
                CountBagsContainingColor(bags, bag.Color, ref containingBags);
            }

            return containingBags;
        }

        private int CountContainingBagsInColor(string bagColor)
        {
            var currentBag = GetBagList().Find(b => b.Color == bagColor);
            int contains = 0;
            foreach (var bag in currentBag.Contains)
            {
                contains += bag.Amount;
                contains += bag.Amount * CountContainingBagsInColor(bag.Color);
            }

            return contains;
        }
    }

    class Bag
    {
        public string Color { get; set; }
        public int Amount { get; set; }
        public List<Bag> Contains { get; set; }
    }
}
