namespace ToyRobot
{
    public interface INotify
    {
        void Message(string message);
    }

    public class Notify : INotify
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}