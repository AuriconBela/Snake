namespace Snake.Model;

internal class Board
{
    private readonly CellType[,] _board = new CellType[Constants.BoardWidth, Constants.BoardHeight];

    public CellType this[int column, int row]
    {
        get => _board[column, row];
        set => _board[column, row] = value;
    }

    public int Width = Constants.BoardWidth;
    public int Height = Constants.BoardHeight;
}
