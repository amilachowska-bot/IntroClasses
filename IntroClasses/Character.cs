namespace IntroClasses;

public abstract class Character
{
    protected Vector2 _position = new Vector2(0, 0);
    private string _avatar = "@";

    public Character(Vector2 startingPosition)
    {
        _position = startingPosition;
    }

    public void Display()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_avatar);
    }

    public void Move(Vector2 direction, Map map)
    {
        Move(direction.X, direction.Y, map);
    }

    public void Move(int diffX, int diffY, Map map)
    {
        int targetX = _position.X + diffX;
        int targetY = _position.Y + diffY;

        if (targetY >= 0 && targetY < Console.BufferHeight && targetY < map.GetHeight())
        {
            if (targetX >= 0 && targetX < Console.BufferWidth && targetX < map.GetRowWidth(targetY))
            {
                if (map.GetCell(targetX, targetY).Visuals != '#')
                { 
                    _position.Y = targetY;
                    _position.X = targetX;
                }
            }
        }
    }

    public abstract bool TakeTurn(Map map);
}