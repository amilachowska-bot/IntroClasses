namespace IntroClasses;

public abstract class Character : GameObject
{
    public Character(char avatar, Vector2 startingPosition, Map map) : base(avatar, startingPosition)
    {
        Cell cell = map.GetCell(_position.X, _position.Y);
        cell.Occupant = this;
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