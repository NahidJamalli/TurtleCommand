using FluentAssertions;
using Xunit;

namespace TurtleCommand.Tests
{
    public class TurtleCommand_Should
    {
        [Fact]
        public void Discard_Move_command_when_the_robot_was_not_placed_on_the_table()
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Move();

            turtleCommand.X.Should().Be(null);
            turtleCommand.Y.Should().Be(null);
            turtleCommand.Facing.Should().Be(null);
        }

        [Fact]
        public void Discard_Left_command_when_the_robot_was_not_placed_on_the_table()
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Left();

            turtleCommand.X.Should().Be(null);
            turtleCommand.Y.Should().Be(null);
            turtleCommand.Facing.Should().Be(null);
        }

        [Fact]
        public void Discard_Right_command_when_the_robot_was_not_placed_on_the_table()
        {
            var turtleCommand = new TurtleCommand();

            turtleCommand.Right();

            turtleCommand.X.Should().Be(null);
            turtleCommand.Y.Should().Be(null);
            turtleCommand.Facing.Should().Be(null);
        }

        [Fact]
        public void Discard_Report_command_when_the_robot_was_not_placed_on_the_table()
        {
            var turtleCommand = new TurtleCommand();

            var result = turtleCommand.Report();

            result.Should().Be(null);
        }
    }
}