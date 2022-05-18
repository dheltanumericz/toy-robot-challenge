namespace ToyRobot
{

    public enum Direction
    {
        NORTH = 0,
        EAST = 1,
        WEST = 2,
        SOUTH = 3,
        NONE = 4
    }
    public interface IRobot
    {
        int currentRow { get; set; }
        int currentColumn { get; set; }
        Direction Direction { get; set; }
        ITable? Table { get; set; }
        void Place(int row, int col, Direction direction);
        void Move();
        void Left();
        void Right();
        string Report();

    }


    public class Robot : IRobot
    {
        public int currentRow { get; set; }
        public int currentColumn { get; set; }
        public Direction Direction { get; set; }
        public ITable? Table { get; set; }

        private bool IsPlaced { get; set; }
        public Robot(ITable table)
        {
            Table = table;
            Direction = Direction.NONE;
        }
        public void Place(int row, int col, Direction direction)
        {
            if (Table != null && Table.IsValidPosition(row, col))
            {
                currentRow = row;
                currentColumn = col;
                Direction = direction;
                IsPlaced = true;
            }
        }

        public void Left()
        {
            if (IsPlaced)
            {
                switch (Direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.WEST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.NORTH;
                        break;
                    case Direction.WEST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.EAST;
                        break;
                    default: break;
                }
            }

        }

        public void Right()
        {
            if (IsPlaced)
            {
                switch (Direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.WEST:
                        Direction = Direction.NORTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.WEST;
                        break;
                    default: break;
                }
            }

        }
        public void Move()
        {
            if (IsPlaced)
            {
                var nextPosition = GetNextPosition(Direction);
                if (Table!.IsValidPosition(nextPosition.x, nextPosition.y))
                {
                    currentRow = nextPosition.x;
                    currentColumn = nextPosition.y;
                }
            }
        }

        public string Report()
        {
            var result = "Nothing to report. Please make sure the PLACE command executed first.";
            if (IsPlaced)
            {
                result = $"Output: {currentRow},{currentColumn},{Direction}";
            }
            return result;
        }



        private (int x, int y) GetNextPosition(Direction direction)
        {
            var col = currentColumn;
            var row = currentRow;
            switch (Direction)
            {
                case Direction.NORTH:
                    col += 1;
                    break;
                case Direction.EAST:
                    row += 1;
                    break;
                case Direction.WEST:
                    row -= 1;
                    break;
                case Direction.SOUTH:
                    col -= 1;
                    break;
                default: break;
            }

            return (row, col);
        }

    }
}