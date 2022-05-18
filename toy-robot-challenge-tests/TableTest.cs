using ToyRobot;
using Xunit;
using FluentAssertions;

namespace ToyRobotTests
{
    public class TableShould
    {
        private readonly ITable _table;

        public TableShould()
        {
            _table = new Table(5, 5);
        }

        [Fact]
        public void ShouldReturnFalseIfPositionIsNotValid()
        {
            var valid = _table.IsValidPosition(6, 1);
            valid.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnTrueIfPositionIsValid()
        {
            var valid = _table.IsValidPosition(5, 5);
            valid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnTrueIfPositionIsInitial()
        {
            var valid = _table.IsValidPosition(0, 0);
            valid.Should().BeTrue();
        }

    }
}