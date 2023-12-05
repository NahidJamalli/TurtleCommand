using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Report_Should
    {
        [Theory]
        [InlineData(0, 0, Direction.North, "0,0,NORTH")]
        [InlineData(1, 2, Direction.East, "1,2,EAST")]
        [InlineData(3, 4, Direction.South, "3,4,SOUTH")]
        [InlineData(4, 0, Direction.West, "4,0,WEST")]
        public void Return_position_when_it_is_valid(int x, int y, string direction, string report)
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(x, y, direction);

            var result = turtleCommand.Report();

            result.Should().Be(report);
        }
    }
}