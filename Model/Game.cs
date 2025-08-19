namespace Snake.Model;

internal class Game
{
    public Snake Snake { get; }
    public Board Board { get; set; } = new();

    public Position? FoodPosition { get; private set; }

    public Game()
    {        
        Snake = new(Direction.ToRight, (x) => IsFood(x));
        Snake.OnEating += Snake_OnEating;
        FoodPosition = NextFood();
    }

    private void Snake_OnEating(object? sender, EventArgs e)
    {
        FoodPosition = NextFood();
    }

    public void PropagateKeyBoardEvent(Keys key)
    {
        if (!ValidKey(key))
        {
            return;
        }
        Snake.Direction = key switch
        {
            Keys.Right => Direction.ToRight,
            Keys.Left => Direction.ToLeft,
            Keys.Up => Direction.ToTop,
            Keys.Down => Direction.ToBottom,
            _ => Snake.Direction
        };
    }

    public StepResult NextFrame()
    {
        if (CanGoAhead() && WontBiteItself())
        {
            Snake.Move();
            return StepResult.Success;
        }
        else
            return StepResult.Failure;
    }

    public Position NextFood()
    {
        // Simple implementation - find a random empty position
        Random random = new();
        Position foodPosition;

        do
        {
            int x = random.Next(0, Constants.BoardWidth);
            int y = random.Next(0, Constants.BoardHeight);
            foodPosition = new Position(x, y);
        }
        while (Snake.Body.Contains(foodPosition)); // Make sure food doesn't appear on snake

        if (FoodPosition is not null)
        {
            Board[FoodPosition.X, FoodPosition.Y] = CellType.Snake;
        }
        Board[foodPosition.X, foodPosition.Y] = CellType.Food;

        return foodPosition;
    }

    private bool CanGoAhead()
    {
        return Snake.Direction switch
        {
            Direction.ToRight => Snake.Head.X < Board.Width-1,
            Direction.ToLeft => Snake.Head.X > 0,
            Direction.ToTop => Snake.Head.Y > 0,
            Direction.ToBottom => Snake.Head.Y < Board.Height-1,
            _ => throw new NotImplementedException(),
        };
    }

    private bool ValidKey(Keys key)
    {
        return Snake.Direction switch
        {
            Direction.ToRight => key == Keys.Up || key == Keys.Down,
            Direction.ToLeft => key == Keys.Up || key == Keys.Down,
            Direction.ToTop => key == Keys.Left || key == Keys.Right,
            Direction.ToBottom => key == Keys.Left || key == Keys.Right,
            _ => throw new NotImplementedException(),
        };
    }

    private bool WontBiteItself()
    {
        return !Snake.Body.Contains(Snake.NewHeadPosition());
    }

    private bool IsFood(Position position)
    {
        return Board[position.X, position.Y] == CellType.Food;
    }
}
