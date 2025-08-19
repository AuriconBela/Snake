namespace Snake.Model;

internal class Snake
{
    private Direction _direction;
    private readonly Func<Position, bool> _isFood;
    private Position _head = new(3, Constants.BoardHeight / 2);
    private readonly List<Position> _body = [];

    public Snake(Direction direction, Func<Position, bool> isFood)
    {
        _direction = direction;
        _isFood = isFood ?? throw new ArgumentNullException(nameof(isFood));
        Init();
    }

    internal Direction Direction { get => _direction; set => _direction = value; }

    internal Position Head { get => _head; set => _head = value; }

    internal int Length => _body.Count;

    internal IReadOnlyList<Position> Body => _body.AsReadOnly();

    internal event EventHandler<EventArgs>? OnEating;

    internal void Eat(Position position)
    {
        MoveHead(position);
        OnEating?.Invoke(this, EventArgs.Empty);
    }

    internal void MoveHead(Position position)
    {
        _head = position;
        _body.Insert(0, position);
    }

    internal void CutTail()
    {
        _body.RemoveAt(_body.Count - 1);
    }

    internal void Move()
    {
        var newHead = NewHeadPosition();

        if (_isFood(newHead))
        {
            Eat(newHead);
        }
        else
        {
            MoveHead(newHead);
            CutTail();
        }        
    }

    internal Position NewHeadPosition()
    {
        Position nextStep;
        switch (Direction)
        {
            case Direction.ToRight:
                nextStep = new(Head.X + 1, Head.Y);
                break;
            case Direction.ToLeft:
                nextStep = new(Head.X - 1, Head.Y);
                break;
            case Direction.ToTop:
                nextStep = new(Head.X, Head.Y - 1);
                break;
            case Direction.ToBottom:
                nextStep = new(Head.X, Head.Y + 1);
                break;
            default:
                throw new NotImplementedException();
        }
        return nextStep;
    }

    private void Init()
    {
        _body.Add(_head);
        _body.Add(new(_head.X - 1, _head.Y));
        _body.Add(new(_head.X - 2, _head.Y));               
    }


}
