
using ToyRobot;

const string VALID_COMMANDS = "PLACE | MOVE | LEFT | RIGHT | REPORT";
const string VALID_FACING = "NORTH | SOUTH | EAST | WEST";

Robot robot = new Robot();

var currentCommand = string.Empty;

while (currentCommand != "QUIT")
{
    var command = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(command)) return;
    var commands = command.Split(" ");
    var isValidCommand = VALID_COMMANDS.Contains(commands[0]);
    currentCommand = commands[0];
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


            robot.currentRow = x;
            robot.currentColumn = y;
            robot.Direction = facing;
        }
        else if (commands[0] == "MOVE")
        {
            if (robot.Direction == "NORTH")
            {
                robot.currentColumn += 1;
            }
            else if (robot.Direction == "EAST")
            {
                robot.currentRow += 1;
            }
            else if (robot.Direction == "WEST")
            {
                robot.currentRow -= 1;
            }
            else if (robot.Direction == "SOUTH")
            {
                robot.currentColumn -= 1;
            }
        }
        else if (commands[0] == "LEFT")
        {
            if (robot.Direction == "NORTH")
            {
                robot.Direction = "WEST";
            }
            else if (robot.Direction == "EAST")
            {
                robot.Direction = "NORTH";
            }
            else if (robot.Direction == "WEST")
            {
                robot.Direction = "SOUTH";
            }
            else if (robot.Direction == "SOUTH")
            {
                robot.Direction = "EAST";
            }
        }
        else if (commands[0] == "RIGHT")
        {
            if (robot.Direction == "NORTH")
            {
                robot.Direction = "EAST";
            }
            else if (robot.Direction == "EAST")
            {
                robot.Direction = "SOUTH";
            }
            else if (robot.Direction == "WEST")
            {
                robot.Direction = "NORTH";
            }
            else if (robot.Direction == "SOUTH")
            {
                robot.Direction = "WEST";
            }
        }
        else if (commands[0] == "REPORT")
        {
            Console.WriteLine($"Output: {robot.currentRow}, {robot.currentColumn}, {robot.Direction}");
        }
        else if (commands[0] == "QUIT")
        {
            return;
        }
    }


}















