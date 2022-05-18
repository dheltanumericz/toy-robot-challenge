namespace ToyRobot
{
    public interface IRobot
    {
        int currentRow { get; set; }
        int currentColumn { get; set; }
    }


    public class Robot
    {
        public int currentRow { get; set; }
        public int currentColumn { get; set; }
        public string? Direction { get; set; }

    }
}