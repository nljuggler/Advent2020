using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Advent2020.Days;

namespace Advent2020
{
    class Program
    {
        static void Main()
        {

//            List<Type> days = Assembly.GetExecutingAssembly().GetTypes().Where(t => Regex.IsMatch(t.Name, "^Day[0-9]+$")).OrderBy(t => t.Name).ToList();
            List<Type> days = Assembly.GetExecutingAssembly().GetTypes().Where(t => Regex.IsMatch(t.Name, "^Day08+$")).OrderBy(t => t.Name).ToList();
            foreach (var dayType in days)
            {
                IDay day = (IDay)Activator.CreateInstance(dayType);
                if (!day.IsImplemented)
                {
                    continue;
                }

                Console.WriteLine($"***** {dayType.Name} *****");
                if (day.IsAssignment1Complete)
                {
                    Console.WriteLine(day.GetAssignment1());
                }

                if (day.IsAssignment2Complete)
                {
                    Console.WriteLine(day.GetAssignment2());
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
