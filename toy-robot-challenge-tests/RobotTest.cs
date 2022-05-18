using ToyRobot;
using Xunit;
using FluentAssertions;

namespace ToyRobotTests
{
    public class RobotShould
    {
        private readonly IRobot _robot;

        public RobotShould()
        {
            ITable _table = new Table(5, 5);
            _robot = new Robot(_table);
        }

        [Fact]
        public void PlaceRobotInSpecifiedLocationHasDirection()
        {
            _robot.Place(1,1, Direction.NORTH);

            _robot.currentRow.Should().Be(1);
            _robot.currentColumn.Should().Be(1);            
            _robot.Direction.Should().Be(Direction.NORTH);

        }

        [Fact]
        public void MoveRobotAndReport()
        {
            _robot.Place(0, 0, Direction.NORTH);
            _robot.Move();
            var report = _robot.Report();

            _robot.currentRow.Should().Be(0);
            _robot.currentColumn.Should().Be(1);
            _robot.Direction.Should().Be(Direction.NORTH);
            report.Should().Be($"Output: {_robot.currentRow},{_robot.currentColumn},{_robot.Direction}");
        }

        [Fact]
        public void PlaceDirectionAndReport()
        {
            _robot.Place(0, 0, Direction.NORTH);
            _robot.Left();
            var report = _robot.Report();

            _robot.currentRow.Should().Be(0);
            _robot.currentColumn.Should().Be(0);
            _robot.Direction.Should().Be(Direction.WEST);
            report.Should().Be($"Output: {_robot.currentRow},{_robot.currentColumn},{_robot.Direction}");
        }

        [Fact]
        public void HandleMultipleDirectionAndMove()
        {
            _robot.Place(1, 2, Direction.EAST);
            _robot.Move();
            _robot.Move();
            _robot.Left();
            _robot.Move();
            var report = _robot.Report();

            _robot.currentRow.Should().Be(3);
            _robot.currentColumn.Should().Be(3);
            _robot.Direction.Should().Be(Direction.NORTH);
            report.Should().Be($"Output: {_robot.currentRow},{_robot.currentColumn},{_robot.Direction}");
        }

        [Fact]
        public void ShouldNotReportIfRobotIsNotPlaced()
        {
            _robot.Move();
            _robot.Move();
            _robot.Left();
            _robot.Move();
            var report = _robot.Report();
            _robot.currentRow.Should().Be(0);
            _robot.currentColumn.Should().Be(0);
            _robot.Direction.Should().Be(Direction.NONE);
            report.Should().Be("Nothing to report. Please make sure the PLACE command executed first.");
        }

        [Fact]
        public void ShouldNotFallFromTheTable()
        {
            _robot.Place(4, 2, Direction.WEST);
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            var report = _robot.Report();

            _robot.currentRow.Should().Be(0);
            _robot.currentColumn.Should().Be(2);
            _robot.Direction.Should().Be(Direction.WEST);
            report.Should().Be($"Output: {_robot.currentRow},{_robot.currentColumn},{_robot.Direction}");
        }


    }
}