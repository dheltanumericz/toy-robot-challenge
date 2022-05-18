using ToyRobot;

ICommandProcessor processor = new CommandProcessor();
INotify notify = new Notify();
ITable table = new Table(5, 5);
IRobot robot = new Robot(table);

MainProgram main = new MainProgram(processor, notify, robot);

main.Start();
Console.ReadLine();
