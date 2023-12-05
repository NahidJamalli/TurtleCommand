using FakeItEasy;
using Xunit;

namespace TurtleCommand.Tests
{
    public class Simulator_Should
    {
        [Theory]
        [InlineData("PLACE 0,0,NORTH", 0, 0, Direction.North)]
        [InlineData("PLACE 1,2,EAST", 1, 2, Direction.East)]
        [InlineData("PLACE 3,4,SOUTH", 3, 4, Direction.South)]
        [InlineData("PLACE 4,0,WEST", 4, 0, Direction.West)]
        public void Execute_Place_command(string command, int x, int y, string direction)
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);

            simulator.Execute(command);

            A.CallTo(() => turtleCommand.Place(x, y, direction)).MustHaveHappened();
        }

        [Fact]
        public void Execute_Move_command()
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);
            turtleCommand.Place(2, 2, Direction.North);

            simulator.Execute("MOVE");

            A.CallTo(() => turtleCommand.Move()).MustHaveHappened();
        }

        [Fact]
        public void Execute_Left_command()
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);
            turtleCommand.Place(2, 2, Direction.North);

            simulator.Execute("LEFT");

            A.CallTo(() => turtleCommand.Left()).MustHaveHappened();
        }

        [Fact]
        public void Execute_Right_command()
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);
            turtleCommand.Place(2, 2, Direction.North);

            simulator.Execute("RIGHT");

            A.CallTo(() => turtleCommand.Right()).MustHaveHappened();
        }

        [Fact]
        public void Execute_Report_command()
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);
            turtleCommand.Place(2, 2, Direction.North);

            simulator.Execute("REPORT");

            A.CallTo(() => turtleCommand.Report()).MustHaveHappened();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("A")]
        [InlineData("BB")]
        [InlineData("CCC")]
        [InlineData("PLACE x,0,NORTH")]
        [InlineData("PLACE 1,x,EAST")]
        [InlineData("PLACE 11111111111111111111,0,SOUTH")]
        [InlineData("PLACE 0,222222222222222222222,WEST")]
        public void Ignore_invalid_commands(string command)
        {
            var turtleCommand = A.Fake<TurtleCommand>();
            var simulator = new Simulator(turtleCommand);

            simulator.Execute(command);

            A.CallTo(() => turtleCommand.Place(A<int>.Ignored, A<int>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => turtleCommand.Move()).MustNotHaveHappened();
            A.CallTo(() => turtleCommand.Left()).MustNotHaveHappened();
            A.CallTo(() => turtleCommand.Right()).MustNotHaveHappened();
            A.CallTo(() => turtleCommand.Report()).MustNotHaveHappened();
        }
    }
}