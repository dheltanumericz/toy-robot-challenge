namespace ToyRobot
{
    public enum Command
    {
        PLACE,
        MOVE,
        RIGHT,
        LEFT,
        REPORT,
        QUIT,
        INVALID,
        NONE,
    }

    public class RobotCommandParameter
    {
        public RobotCommandParameter()
        {
            Row = 0;
            Column = 0;
            Direction = Direction.NONE;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public Direction Direction { get; set; }
    }


    public interface IRobotCommand
    {
        Command Command { get; set; }
        RobotCommandParameter Parameters { get; set; }
    }



    public class RobotCommand : IRobotCommand
    {

        public RobotCommand()
        {
            Command = Command.INVALID;
            Parameters = new RobotCommandParameter();
        }
        public Command Command { get; set; }
        public RobotCommandParameter Parameters { get; set; }

    }
}