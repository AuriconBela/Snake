using Snake.Model;

namespace Snake.Representation;

internal class GameDrawer
{
    private readonly PictureBox _pictureBox;
    private readonly Game _game;

    public GameDrawer(PictureBox pictureBox, Game game)
    {
        _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
        _game = game ?? throw new ArgumentNullException(nameof(game));

        _pictureBox.Paint += Draw;
    }

    private void Draw(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // Calculate cell size based on PictureBox dimensions
        float cellWidth = (float)_pictureBox.Width / Constants.BoardWidth;
        float cellHeight = (float)_pictureBox.Height / Constants.BoardHeight;

        // Fill background
        g.FillRectangle(Constants.BackGroundBrush, 0, 0, _pictureBox.Width, _pictureBox.Height);

        // Draw grid
        DrawGrid(g, cellWidth, cellHeight);

        // Draw snake
        DrawSnake(g, cellWidth, cellHeight);

        // Draw food
        DrawFood(g, cellWidth, cellHeight);
    }

    private void DrawGrid(Graphics g, float cellWidth, float cellHeight)
    {
        // Draw vertical lines
        for (var x = 0; x <= Constants.BoardWidth; x++)
        {
            float lineX = x * cellWidth;
            g.DrawLine(Constants.GridPen, lineX, 0, lineX, _pictureBox.Height);
        }

        // Draw horizontal lines
        for (var y = 0; y <= Constants.BoardHeight; y++)
        {
            float lineY = y * cellHeight;
            g.DrawLine(Constants.GridPen, 0, lineY, _pictureBox.Width, lineY);
        }
    }

    private void DrawSnake(Graphics g, float cellWidth, float cellHeight)
    {
        // Draw all snake body segments
        foreach (var segment in _game.Snake.Body)
        {
            RectangleF segmentRect = new (
                segment.X * cellWidth,
                segment.Y * cellHeight,
                cellWidth,
                cellHeight
            );
            g.FillRectangle(Constants.SnakeBrush, segmentRect);
        }
    }

    private void DrawFood(Graphics g, float cellWidth, float cellHeight)
    {
        if (_game.FoodPosition is null)
        {
            return;
        }

        RectangleF foodRect = new(
            _game.FoodPosition.X * cellWidth,
            _game.FoodPosition.Y * cellHeight,
            cellWidth,
            cellHeight
        );
        g.FillRectangle(Constants.FoodBrush, foodRect);
    }
}
