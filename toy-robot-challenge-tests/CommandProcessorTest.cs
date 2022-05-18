using ToyRobot;
using Xunit;
using FluentAssertions;

namespace ToyRobotTests
{
    public class CommandProcessorShould
    {
        private readonly ICommandProcessor _commandProcessor;

        public CommandProcessorShould()
        {
            _commandProcessor = new CommandProcessor();
        }

        [Fact]
        public void ReturnInvalidCommandIfCommandNotValid()
        {
            var command = _commandProcessor.Process("HELLO WORLD");

            command.Command.Should().Be(Command.INVALID);
            command.Parameters.Column.Should().Be(0);
            command.Parameters.Row.Should().Be(0);
            command.Parameters.Direction.Should().Be(Direction.NONE);
        }

        [Fact]
        public void ReturnInvalidCommandIfInvalidFormat()
        {
            var command = _commandProcessor.Process("PLACE 1, 1, NORTH");

            command.Command.Should().Be(Command.INVALID);
            command.Parameters.Column.Should().Be(0);
            command.Parameters.Row.Should().Be(0);
            command.Parameters.Direction.Should().Be(Direction.NONE);
        }

        [Fact]
        public void ReturnInvalidCommandIfIsEmpty()
        {
            var command = _commandProcessor.Process("    ");

            command.Command.Should().Be(Command.INVALID);
            command.Parameters.Column.Should().Be(0);
            command.Parameters.Row.Should().Be(0);
            command.Parameters.Direction.Should().Be(Direction.NONE);
        }

        [Fact]
        public void ReturnPlaceCommand()
        {
            var command = _commandProcessor.Process("PLACE 1,1,NORTH");

            command.Command.Should().Be(Command.PLACE);
            command.Parameters.Column.Should().Be(1);
            command.Parameters.Row.Should().Be(1);
            command.Parameters.Direction.Should().Be(Direction.NORTH);
        }

        [Fact]
        public void ReturnMoveCommand()
        {
            var command = _commandProcessor.Process("MOVE");

            command.Command.Should().Be(Command.MOVE);
            command.Parameters.Column.Should().Be(0);
            command.Parameters.Row.Should().Be(0);
            command.Parameters.Direction.Should().Be(Direction.NONE);
        }
    }
}