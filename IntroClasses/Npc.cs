namespace IntroClasses;

public class Npc : Character
{
    List<Vector2> availableDirections = [
        new Vector2(-1, 0), // w lewo
        new Vector2(1, 0), // w prawo
        new Vector2(0, -1), // w górę
        new Vector2(0, 1) // w dół
    ];
    public Npc(char avatar, Vector2 startingPosition, Map map) : base(avatar, startingPosition, map)
    {
        
    }

    public override bool TakeTurn(Map map)
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Cell cell = map.GetCell(_position.X, _position.Y);


        int index = Random.Shared.Next(availableDirections.Count);
        Vector2 direction = availableDirections[index];
        if (Move(direction, map))
        {
            Console.Write(cell.Visuals);
            cell.Occupant = null;
        }
        Display();
        return true;
    }
}