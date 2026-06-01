namespace IntroClasses;

public abstract class Character
{
    protected Vector2 _position = new Vector2(0, 0);
    private char _avatar = '@';

    public Character(char avatar, Vector2 startingPosition, Map map)
    {
        _avatar = avatar;
        _position = startingPosition;
        Cell cell = map.GetCell(_position.X, _position.Y);
        cell.Occupant = this;
    }

    public void Display()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_avatar);
    }

    public bool Move(Vector2 direction, Map map)
    {
        return Move(direction.X, direction.Y, map);
    }

    public bool Move(int diffX, int diffY, Map map)
    {
        int targetX = _position.X + diffX;
        int targetY = _position.Y + diffY;

        if (targetY >= 0 && targetY < Console.BufferHeight && targetY < map.GetHeight())
        {
            if (targetX >= 0 && targetX < Console.BufferWidth && targetX < map.GetRowWidth(targetY))
            {
                Cell cell = map.GetCell(targetX, targetY);
                if (cell.Visuals != '#' && cell.Occupant == null)
                { 
                    _position.Y = targetY;
                    _position.X = targetX;
                    cell.Occupant = this;
                    return true;
                }
            }
        }

        return false;
    }

    public abstract bool TakeTurn(Map map);
}