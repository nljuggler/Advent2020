using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2020.Helpers;

namespace Advent2020.Days
{
    class Day05 : IDay
    {
        public bool IsImplemented => true;
        public bool IsAssignment1Complete => true;
        public bool IsAssignment2Complete => true;
        private List<string> Lines => DayFileReader.Read(5);
        private List<string> OrderedLines => Lines.OrderBy(l => l.Substring(0, 7)).ThenByDescending(l => l.Substring(7)).ToList();
        
        public string GetAssignment1()
        {
            var highSeat = OrderedLines.First();
            var seatId = GetSeatId(highSeat);
            return $"The highest SeatId is {seatId}";
        }

        public string GetAssignment2()
        {
            var currentLineId = GetSeatId(OrderedLines[0]);
            for (var index = 1; index < OrderedLines.Count; index++)
            {
                var newSeatId = GetSeatId(OrderedLines[index]);
                if (currentLineId - newSeatId != 1)
                {
                    return "My seat ID is: " + (currentLineId - 1);
                }
                currentLineId = newSeatId;
            }
            return "You should not be on this plane!";
        }

        private int GetSeatId(string line)
        {
            line = line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');
            return Convert.ToInt32(line, 2);
        }
    }
}
