using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Right_Should
    {
        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void Rotate_robot_right_90_degrees(string before, string after)
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(1, 1, before);

            turtleCommand.Right();

            turtleCommand.Facing.Should().Be(after);
        }
    }
}