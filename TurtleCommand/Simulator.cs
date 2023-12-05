using System;
using System.Text.RegularExpressions;

namespace TurtleCommand
{
    public class Simulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");

        private readonly TurtleCommand _turtleCommand;

        public Simulator(TurtleCommand toyRobot)
        {
            _turtleCommand = toyRobot;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            if (command == "MOVE") _turtleCommand.Move();
            if (command == "LEFT") _turtleCommand.Left();
            if (command == "RIGHT") _turtleCommand.Right();
            if (command == "REPORT") Console.WriteLine(_turtleCommand.Report());

            var match = _placeCommand.Match(command);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    _turtleCommand.Place(x, y, direction);
                }
            }
        }
    }
}