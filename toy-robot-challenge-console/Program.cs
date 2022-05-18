
const string VALID_COMMANDS = "PLACE | MOVE | LEFT | RIGHT | REPORT";
const string VALID_FACING = "NORTH | SOUTH | EAST | WEST";

var command = Console.ReadLine();

if (string.IsNullOrWhiteSpace(command)) return;

var commands = command.Split(" ");

var isValidCommand = VALID_COMMANDS.Contains(commands[0]);

if (isValidCommand)
{
    if (commands[0] == "PLACE")
    {
        if (string.IsNullOrWhiteSpace(commands[1])) return;

        var placeCommands = commands[1].Split(",");

        if (placeCommands.Count() < 3) return;

        var xPosition = placeCommands[0];
        var yPosition = placeCommands[1];
        var facing = placeCommands[2];

        if (!int.TryParse(xPosition, out int x)) return;
        if (!int.TryParse(yPosition, out int y)) return;
        if (!VALID_FACING.Contains(facing)) return;


        Console.WriteLine($"Robot will be placed on X:{xPosition} Y:{yPosition} facing {facing}");
    }
}


Console.ReadLine();


