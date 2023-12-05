using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Left_Should
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void Rotate_robot_left_90_degrees(string before, string after)
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(1, 1, before);

            turtleCommand.Left();

            turtleCommand.Facing.Should().Be(after);
        }
    }
}