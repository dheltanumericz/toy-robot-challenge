namespace toy_robot_challenge_console
{
    public interface ITableTop
    {
        int RowsCount { get; set; }
        int ColumnsCount { get; set; }
    }

    public class TableTop : ITableTop
    {
        public TableTop(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
        }

        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }
    }
}