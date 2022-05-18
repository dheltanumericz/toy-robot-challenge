namespace ToyRobot
{
    public class MainProgram
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly INotify _notify;
        private readonly IRobot _robot;

        public MainProgram(
            ICommandProcessor commandProcessor,
            INotify notify,
            IRobot robot)
        {
            _commandProcessor = commandProcessor;
            _notify = notify;
            _robot = robot;
        }

        public void Start()
        {
            var command = Command.NONE;
            while (command != Command.QUIT)
            {
                var getCommand = Console.ReadLine();
                var robotCommand = _commandProcessor.Process(getCommand!);

                switch (robotCommand.Command)
                {
                    case Command.INVALID:
                        _notify.Message("Unrecognized or invalid command. Example: PLACE 0,0,NORTH");
                        break;
                    case Command.PLACE:
                        _robot.Place(
                            robotCommand.Parameters.Row,
                            robotCommand.Parameters.Column,
                            robotCommand.Parameters.Direction);
                        break;
                    case Command.MOVE:
                        _robot.Move();
                        break;
                    case Command.LEFT:
                        _robot.Left();
                        break;
                    case Command.RIGHT:
                        _robot.Right();
                        break;
                    case Command.REPORT:
                        var report = _robot.Report();
                        _notify.Message(report);
                        break;
                    default: break;
                }
                command = robotCommand.Command;
            }
        }

    }
}