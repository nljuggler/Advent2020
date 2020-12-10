using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day08 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(8);
        public string GetAssignment1()
        {
            return $"The value of the accumulator just before the infinitive loops starts is: {RunProgram(Lines).accumulator}"; 
        }

        public string GetAssignment2()
        {
            string[] commands = {"jmp", "nop"};
            for (var index = 0; index < Lines.Count; index++)
            {
                if (commands.Contains(Lines[index].Substring(0, 3)))
                {
                    var clonedLines = new List<string>(Lines);
                    clonedLines[index] = (clonedLines[index].StartsWith("jmp") ? "nop" : "jmp") + clonedLines[index].Substring(3);
                    var result = RunProgram(clonedLines);
                    if (!result.looping)
                    {
                        return $"The value of the accumulator with the fixed code is: {result.accumulator}";
                    }
                }
            }

            return "I couldn't fix the code.";
        }

        private (bool looping, int accumulator) RunProgram(List<string> lines)
        {
            var accumulator = 0;
            var linesHit = new HashSet<int>();
            for (var index = 0; index < lines.Count; index++)
            {
                if (linesHit.Contains(index))
                {
                    return (true, accumulator);
                }

                linesHit.Add(index);

                var line = lines[index];
                string cmd = line.Substring(0, 3);
                int count = Convert.ToInt32(line.Substring(3));
                if (cmd == "acc")
                {
                    accumulator += count;
                }
                else if (cmd == "jmp")
                {
                    index = index + count - 1;
                }
            }
            return (false, accumulator);
        }
    }
}
