namespace ToyRobot
{
    public interface ITable
    {
        int RowsCount { get; set; }
        int ColumnsCount { get; set; }
        bool IsValidPosition(int row, int colum);
    }

    public class Table : ITable
    {
        public Table(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
        }

        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }

        public bool IsValidPosition(int row, int column)
        {
            var result = (row >= 0 && row <= RowsCount) && (column >= 0 && column <= ColumnsCount);
            return result;
        }


    }
}