using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Place_Should
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Set_robots_X_position(int x)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(x, 2, Direction.South);

            turtleCommand.X.Should().Be(x);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Set_robots_Y_position(int y)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(1, y, Direction.South);

            turtleCommand.Y.Should().Be(y);
        }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void Set_robots_direction(string direction)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(1, 2, direction);

            turtleCommand.Facing.Should().Be(direction);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(5)]
        [InlineData(6)]
        public void Discard_command_when_X_is_invalid(int x)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(x, 2, Direction.South);

            turtleCommand.X.Should().NotBe(x);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(5)]
        [InlineData(6)]
        public void Discard_command_when_Y_is_invalid(int y)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(1, y, Direction.South);

            turtleCommand.Y.Should().NotBe(y);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("BB")]
        [InlineData("CCC")]
        public void Discard_command_when_direction_is_invalid(string direction)
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Place(1, 2, direction);

            turtleCommand.Facing.Should().NotBe(direction);
        }
    }
}