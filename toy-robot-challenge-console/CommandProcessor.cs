public enum RobotCommands
{
    Place = 0,
    Move = 1,
    Left = 2,
    Right = 3,
    Report = 4,
    Quit = 5
}


public class CommandProcessor
{
    const string VALID_COMMANDS = "PLACE | MOVE | LEFT | RIGHT | REPORT";
    const string VALID_FACING = "NORTH | SOUTH | EAST | WEST";

    public string InputCommand { get; set; }

    public RobotCommands Command { get; set; }
    public CommandProcessor(string inputCommand)
    {
        InputCommand = inputCommand;
    }

    public void Process()
    {




    }



}