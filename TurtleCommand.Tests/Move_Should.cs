using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Move_Should
    {
        [Fact]
        public void Move_North_when_facing_North()
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(2, 2, Direction.North);

            turtleCommand.Move();

            turtleCommand.X.Should().Be(2);
            turtleCommand.Y.Should().Be(3);
        }

        [Fact]
        public void Move_East_when_facing_East()
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(2, 2, Direction.East);

            turtleCommand.Move();

            turtleCommand.X.Should().Be(3);
            turtleCommand.Y.Should().Be(2);
        }

        [Fact]
        public void Move_South_when_facing_South()
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(2, 2, Direction.South);

            turtleCommand.Move();

            turtleCommand.X.Should().Be(2);
            turtleCommand.Y.Should().Be(1);
        }

        [Fact]
        public void Move_West_when_facing_West()
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(2, 2, Direction.West);

            turtleCommand.Move();

            turtleCommand.X.Should().Be(1);
            turtleCommand.Y.Should().Be(2);
        }

        [Theory]
        [InlineData(4, 4, Direction.North)]
        [InlineData(4, 4, Direction.East)]
        [InlineData(0, 0, Direction.South)]
        [InlineData(0, 0, Direction.West)]
        public void Not_cause_the_robot_to_fall_outside_the_table(int x, int y, string direction)
        {
            var turtleCommand = new TurtleCommand();
            turtleCommand.Place(x, y, direction);

            turtleCommand.Move();

            turtleCommand.X.Should().Be(x);
            turtleCommand.Y.Should().Be(y);
        }
    }
}