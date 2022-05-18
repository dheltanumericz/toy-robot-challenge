namespace toy_robot_challenge_console
{
    public interface IPosition
    {
        int CurrentRow { get; set; }
        int CurrentColumn { get; set; }
    }
    public class Position : IPosition
    {

        public Position(int row, int column)
        {
            CurrentRow = row;
            CurrentColumn = column;
        }

        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
    }
}