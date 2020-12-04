namespace Advent2020.Days
{
    interface IDay
    {
        bool IsImplemented { get; }

        bool IsAssignment1Complete { get; }

        bool IsAssignment2Complete { get; }

        string GetAssignment1();
        string GetAssignment2();
    }
}
