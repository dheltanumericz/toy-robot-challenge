namespace ToyRobot
{
    public interface ICommandProcessor
    {
        RobotCommand Process(string command);
    }

    public class CommandProcessor : ICommandProcessor
    {
        const string VALID_COMMANDS = "PLACE | MOVE | LEFT | RIGHT | REPORT | QUIT";
        const string VALID_DIRECTIONS = "NORTH | SOUTH | EAST | WEST";
        public RobotCommand Process(string command)
        {
            var result = new RobotCommand();
            if (string.IsNullOrWhiteSpace(command)) return result;
            try
            {
                var commands = command.Split(" ", StringSplitOptions.TrimEntries);

                // It is expected to have the main command and parameters
                if (commands.Length > 2) return result;

                // Check if the main command is in the valid command list
                if (!VALID_COMMANDS.Contains(commands[0])) return result;

                // Transform the main command to enum
                if (!Enum.TryParse<Command>(commands[0], out Command commandResult)) return result;

                // We need a parameter of PLACE is the command
                if (commandResult == Command.PLACE && commands.Length == 2)
                {
                    var parameters = commands[1].Split(",", StringSplitOptions.TrimEntries);

                    //Expected to have to parameters only
                    if (parameters.Length < 2 || parameters.Length > 3) return result;

                    if (!int.TryParse(parameters[0], out int x)) return result;
                    if (!int.TryParse(parameters[1], out int y)) return result;
                    if (!Enum.TryParse<Direction>(parameters[2], out Direction directionResult)) return result;

                    result.Parameters.Row = x;
                    result.Parameters.Column = y;
                    result.Parameters.Direction = directionResult;
                }
                result.Command = commandResult;
                return result;
            }
            catch (System.Exception)
            {
                return result;
            }
        }
    }
}